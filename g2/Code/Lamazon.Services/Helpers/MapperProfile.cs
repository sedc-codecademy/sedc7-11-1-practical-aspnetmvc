using AutoMapper;
using Lamazon.Domain.Models;
using Lamazon.WebModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lamazon.Services.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductViewModel>();

            CreateMap<Order, OrderViewModel>();

            CreateMap<User, RegisterViewModel>();

            CreateMap<User, UserViewModel>();
        }
    }
}
