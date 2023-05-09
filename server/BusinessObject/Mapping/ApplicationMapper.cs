using AutoMapper;
using BusinessObject.DTOs.Category;
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

        }
    }
}
