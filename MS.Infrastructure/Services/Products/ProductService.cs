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

namespace MS.Infrastructure.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly MSDbContext _db;
        private readonly IMapper _mapper;

        public ProductService(MSDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            if (product == null)
            {
                throw new EntityNotFoundException();
            }
            product.IsDelete = true;
            _db.Products.Update(product);
            _db.SaveChanges();
            return product.Id;
        }

        public async Task<ProductViewModel> Get(int Id)
        {
            var product =  _db.Products.Include(x => x.Category)
                .Include(x => x.Store).SingleOrDefault(x => x.Id == Id && !x.IsDelete);
            if (product == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<int> Create(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _db.Products.Add(product);
            _db.SaveChanges();
            return product.Id;
        }

        public async Task<int> Update(UpdateProductDto dto)
        {
            var product = _db.Products.SingleOrDefault(x => !x.IsDelete && x.Id == dto.Id);
            if (product == null)
            {
                //throw new EntityNotFoundException();
            }
            var updatedProduct = _mapper.Map<UpdateProductDto, Product>(dto, product);
            _db.Products.Update(updatedProduct);
            _db.SaveChanges();
            return updatedProduct.Id;
        }



    }
}

