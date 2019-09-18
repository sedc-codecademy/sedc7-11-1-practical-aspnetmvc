using AutoMapper;
using DataAccess.Interfaces;
using Domain.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WebModels.ViewModels;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            IEnumerable<Product> products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public int RemoveProduct(int id)
        {
            return _productRepository.Delete(id);
        }
    }
}
