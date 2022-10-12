using AutoMapper;
using MeterStors.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MS.Core.Dtos;
using MS.Core.Exceptions;
using MS.Core.RequestFeatures;
using MS.Core.ViewModel;
using MS.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MS.Infrastructure.Services;

namespace MS.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly MSDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        //private readonly IFileService _fileService;

        public UserService(MSDbContext db,  IMapper mapper , UserManager<User> userManager, IEmailService emailService)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            //_fileService = fileService;
        }

        
        public async Task<List<UserViewModel>> GetAll([FromQuery]
         UserParameters userParameters)
        {
            var users = _db.Users.Where(x => !x.IsDelete &&(x.FullName.Contains(userParameters.SearchTerm)
                || x.Email.Contains(userParameters.SearchTerm) || x.PhoneNumber.Contains(userParameters.SearchTerm)
                || string.IsNullOrWhiteSpace(userParameters.SearchTerm)))
            .OrderBy(e => e.FullName)
            .Skip((userParameters.PageNumber - 1) * userParameters.PageSize)
            .Take(userParameters.PageSize)
            .ToList();
            return _mapper.Map<List<UserViewModel>>(users);
        }

        public async Task<UserViewModel> Get(string id)
        {
            var user =  _db.Users.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UserViewModel>(user);
        }
        public UserViewModel GetUserByUsername(string username)
        {
            var user = _db.Users.SingleOrDefault(x => x.UserName == username && !x.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UserViewModel>(user);
        }
        public async Task<string> Create (CreateUserDto dto)
        {
            var emailOrPhoneIsExist = _db.Users.Any(x => !x.IsDelete && 
            (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber));

            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }

            var user = _mapper.Map<User>(dto);
            user.UserName = dto.Email;
            var password = GenratePassword();
            try
            {
                var result = await _userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    throw new OperationFailedException();
                }

            }
            catch (Exception e)
            {

            }


            await _emailService.Send(user.Email, "New Account !", $"Username is : {user.Email} and Password is { password }");

            return user.Id;
        }
        
        public async Task<string> Update(UpdateUserDto dto)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == dto.Id);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }

            var emailOrPhoneIsExist = _db.Users.Any(x => !x.IsDelete &&
            (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber) && x.Id != dto.Id);
            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }
            var updatedUser = _mapper.Map<UpdateUserDto, User>(dto, user);

            _db.Users.Update(updatedUser);
            _db.SaveChanges();
            return user.Id;
        }
        public async Task<string> Delete (string id)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            if(user == null)
            {
                throw new EntityNotFoundException();
            }
            user.IsDelete = true;
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user.Id;

        }
        private string GenratePassword()
        {
            return Guid.NewGuid().ToString().Substring(1, 8);
        }
    }
}
