using AutoMapper;
using MS.Core.Dtos;
using MS.Core.ViewModel;
using MS.Core.ViewModels;
using MS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Infrastructure.AutoMapper
{
 public  class MapperProfile : Profile
    {
        public MapperProfile() {

            CreateMap<Category, CategoryViewModel>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();


            CreateMap<User, UserViewModel>()
                .ForMember(x => x.ImageUrl, x => x.Ignore())
                .ForMember(x => x.UserType, x => x.Ignore());
            CreateMap<CreateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<UpdateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<User, UpdateUserDto>();

            CreateMap<Store, StoreViewModel>();
            CreateMap<CreateStoreDto, Store>();
            CreateMap<UpdateStoreDto, Store>();
            CreateMap<Store, UpdateStoreDto>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, UpdateProductDto>();


        }
    }
}
