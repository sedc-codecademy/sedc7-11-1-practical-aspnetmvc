using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.WebModels_.Enums;
using SEDC.Lamazon.WebModels_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.Lamazon.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public int CreateProduct(ProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var products = _productRepository.GetAll().ToList();

            ProductViewModel model = new ProductViewModel();
            List<ProductViewModel> mappedProducts = new List<ProductViewModel>();

            foreach (var product in products)
            {
                model.Id = product.Id;
                model.Name = product.Name;
                model.Description = product.Description;
                model.Category = (CategoryTypeViewModel)product.Category;
                model.Price = product.Price;

                mappedProducts.Add(model);
            }

            return mappedProducts;
        }

        public ProductViewModel GetProductById(int id)
        {
            ProductViewModel model = new ProductViewModel();
            var product =  _productRepository.GetById(id);
            
            model.Id = product.Id;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Category = (CategoryTypeViewModel)product.Category;
            model.Price = product.Price;

            return model;
        }

        public int RemoveProduct(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateProduct(ProductViewModel product)
        {
            throw new NotImplementedException();
        }
    }
}
