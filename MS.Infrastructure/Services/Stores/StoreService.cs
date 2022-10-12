using AutoMapper;
using MeterStors.API.Data;
using Microsoft.EntityFrameworkCore;
using MS.Core.Dtos;
using MS.Core.Exceptions;
using MS.Core.ViewModels;
using MS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Infrastructure.Services.Stores
{
    public class StoreService : IStoreService
    {
        private readonly MSDbContext _db;
        private readonly IMapper _mapper;

        public StoreService(MSDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<StoreViewModel> Get(int Id)
        {
            var store = _db.Stores.Include(x => x.Category)
                .Include(x => x.Owner).SingleOrDefault(x => x.Id == Id && !x.IsDelete);
            if (store == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<StoreViewModel>(store);
        }

        public async Task<int> Create(CreateStoreDto dto)
        {
            var store = _mapper.Map<Store>(dto);
            _db.Stores.Add(store);
            _db.SaveChanges();
            return store.Id;
        }

        public async Task<int> Update(UpdateStoreDto dto)
        {
            var store = _db.Stores.SingleOrDefault(x => !x.IsDelete && x.Id == dto.Id);
            if (store == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedStore = _mapper.Map<UpdateStoreDto, Store>(dto, store);
            _db.Stores.Update(updatedStore);
            _db.SaveChanges();
            return updatedStore.Id;
        }

        public async Task<int> Delete(int id)
        {
            var store = _db.Stores.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            if (store == null)
            {
                throw new EntityNotFoundException();
            }
            store.IsDelete = true;
            _db.Stores.Update(store);
            _db.SaveChanges();
            return store.Id;
        }

      

        //public async Task<int> Create(CreateCategoryDto dto)
        //{
        //    var category = _mapper.Map<Category>(dto);
        //    _db.Categories.Add(category);
        //    _db.SaveChanges();
        //    return category.Id;
        //}


        //public async Task<int> Update(UpdateCategoryDto dto)
        //{
        //    var category = _db.Categories.SingleOrDefault(x => !x.IsDelete && x.Id == dto.Id);
        //    if (category == null)
        //    {
        //        //throw new EntityNotFoundException();
        //    }
        //    var updatedCategory = _mapper.Map<UpdateCategoryDto, Category>(dto, category);
        //    _db.Categories.Update(updatedCategory);
        //    _db.SaveChanges();
        //    return updatedCategory.Id;
        //}


        //public async Task<UpdateCategoryDto> Get(int Id)
        //{
        //    var category = await _db.Categories.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
        //    if (category == null)
        //    {
        //        throw new EntityNotFoundException();
        //    }
        //    return _mapper.Map<UpdateCategoryDto>(category);
    }       
}

