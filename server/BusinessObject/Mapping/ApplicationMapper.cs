using AutoMapper;
using BusinessObject.DTOs.Auth;
using BusinessObject.DTOs.Category;
using BusinessObject.DTOs.Customer;
using BusinessObject.DTOs.Product;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Mapping
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            //Product
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductCreateUpdateDTO>().ReverseMap();
            //Category
            CreateMap<Category , CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
            //Account
            CreateMap<Account, SignInDTO>().ReverseMap();
            CreateMap<Account, AccountDTO>()
                .ForMember(
                    dest => dest.CustomerName,
                    opt => opt.MapFrom(src => src.Customer!.FullName))
                .ForMember(
                    dest => dest.EmployeeName,
                    opt => opt.MapFrom(src => src.Employee!.FullName)).ReverseMap();
            //Customer
            CreateMap<Customer, CustomerCreateUpdateDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
