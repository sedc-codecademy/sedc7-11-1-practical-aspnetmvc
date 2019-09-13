using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Enums;
using Lamazon.Domain.Models;
using Lamazon.Services.Interfaces;
using Lamazon.WebModels.Enums;
using Lamazon.WebModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lamazon.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductService(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var allProducts = _productRepo.GetAll();
            //var allViewProducts = new List<ProductViewModel>();

            //foreach (Product product in allProducts)
            //{
            //    allViewProducts.Add(
            //        new ProductViewModel
            //        {
            //            Id = product.Id,
            //            Name = product.Name,
            //            Description = product.Description,
            //            Category = (CategoryTypeViewModel)product.Category,
            //            Price = product.Price,
            //        }
            //    );
            //}

            return allProducts.Select(p => 
                new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Category = (CategoryTypeViewModel)p.Category,
                    Price = p.Price,
                });
        }

        public ProductViewModel GetProductById(int id)
        {
            Product product = _productRepo.GetById(id);

            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = (CategoryTypeViewModel)product.Category,
                Price = product.Price,
            };
        }

        public void CreateProduct(ProductViewModel product)
        {
            Product productDomain = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Category = (CategoryType)product.Category,
                Price = product.Price
            };

            _productRepo.Insert(productDomain);
        }

        public void UpdateProduct(ProductViewModel product)
        {
            Product productDomain = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Category = (CategoryType)product.Category,
                Price = product.Price
            };

            _productRepo.Update(productDomain);
        }

        public void RemoveProduct(int id)
        {
            _productRepo.Delete(id);
        }
    }
}
