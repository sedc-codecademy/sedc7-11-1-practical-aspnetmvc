using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebModels.ViewModels;

namespace Services.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.Status, src => src.MapFrom(x => x.Status))
                .ForMember(dest => dest.DateOfOrder, src => src.Ignore())
                .ForMember(dest => dest.Price, src => src.Ignore())
                .ForMember(dest => dest.Products, src => src.MapFrom(x => x.ProductOrders.Select(y => y.Product)))
                .ReverseMap()
                .ForMember(dest => dest.ProductOrders, src => src.Ignore());

            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Category, src => src.MapFrom(x => x.Category))
                .ReverseMap()
                .ForMember(dest => dest.ProductOrders, src => src.Ignore());

            CreateMap<Invoice, InvoiceViewModel>()
                .ForMember(dest => dest.PaymentType, src => src.MapFrom(x => x.PaymentType))
                .ReverseMap();
        }
    }
}
