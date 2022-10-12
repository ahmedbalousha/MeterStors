using AutoMapper;
using MeterStors.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MS.Core.Constant;
using MS.Core.Dtos;
using MS.Core.Exceptions;
using MS.Core.Options;
using MS.Core.ViewModel;
using MS.Core.ViewModels;
using MS.Data.Models;
using MS.Infrastructure.Services.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MS.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly MSDbContext _db;
        private readonly UserManager<User> _userManger;
        private readonly IMapper _mapper;
        private readonly JwtOptions _options;



        public AuthService(MSDbContext db, UserManager<User> userManger, IMapper mapper, IOptions <JwtOptions> options)
        {
            _db = db;
            _userManger = userManger;
            _mapper = mapper;
            _options = options.Value;
        }
        public async Task<LoginResponseViewModel> Login (LoginDto dto)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.UserName == dto.Username);
            if (user == null)
            {
                throw new InvalidUsernameOrPassword();
            }
            var result = await _userManger.CheckPasswordAsync(user, dto.Password);
            if (!result)
            {
                throw new InvalidUsernameOrPassword();

            }
           
            var response = new LoginResponseViewModel();
            response.AccessToken = await GenerateAccessToken(user);
            response.User = _mapper.Map<UserViewModel>(user);
            return response;
        }
        private async Task <AccessTokenViewModel> GenerateAccessToken (User user)
        {
            var roles = await _userManger.GetRolesAsync(user);

            var claims = new List<Claim>(){
                new Claim (JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim (Claims.UserId, user.Id),
                new Claim (Claims.Phone, user.PhoneNumber),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            if (roles.Any())
            {
                claims.Add(new Claim(ClaimTypes.Role, string.Join(",", roles)));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecurityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMonths(1);
            var accessToken = new JwtSecurityToken(_options.Issure,
                _options.Issure,
                claims,
                expires: expires,
                signingCredentials: credentials

                );
            var result = new AccessTokenViewModel()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                ExpireAt = expires
            };

            return result ;

        }

    }
}
