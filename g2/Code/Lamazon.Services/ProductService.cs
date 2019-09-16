using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Enums;
using Lamazon.Domain.Models;
using Lamazon.Services.Helpers;
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
        private readonly ManualMapper _mapper;

        public ProductService(IRepository<Product> productRepo, ManualMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            //var allProducts = _productRepo.GetAll();
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

            return _productRepo.GetAll()
                .Select(p => _mapper.ProductToViewModel(p))
                .ToList();
        }

        public ProductViewModel GetProductById(int id)
        {
            Product product = _productRepo.GetById(id);
            if (product == null)
                throw new Exception("Product does not exist");

            return _mapper.ProductToViewModel(product);
        }

        public void CreateProduct(ProductViewModel product)
        {
            _productRepo.Insert(
                _mapper.ProductToDomainModel(product)
            );
        }

        public void UpdateProduct(ProductViewModel product)
        {
            _productRepo.Update(
                _mapper.ProductToDomainModel(product)
            );
        }

        public void RemoveProduct(int id)
        {
            _productRepo.Delete(id);
        }
    }
}
