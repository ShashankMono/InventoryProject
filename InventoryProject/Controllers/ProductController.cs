using InventoryProject.Exceptions;
using InventoryProject.Models;
using InventoryProject.Repositories;
using InventoryProject.TypeOfTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Controllers
{
    internal class ProductController:Controller
    {
        private ProductRepo _repo;

        public ProductController()
        {
            _repo = new ProductRepo();
        }

        public void AddNewProduct( string name, string description, int quantity, double unitprice,int inventoryId)
        {
            if(quantity <= 0)
            {
                throw new QuantityCannotBeZeroOrNegativException("Quantity cannot be zeror or negative\n");
            }
            Product newProduct = new Product()
            {
                Name = name,
                Description = description,
                Quantity = quantity,
                UnitPrice = unitprice,
                InventoryId = inventoryId,
            };
            _repo.Add(newProduct);
            Product product = _repo.GetByName(newProduct.Name);
            AddTransaction(product,TypeOfTransactions.Add);
        }

        public void AddTransaction(Product product,TypeOfTransactions type)
        {
            Transaction transaction = new Transaction()
            {
                ProductId = product.ProductId,
                Quantity = product.Quantity,
                Type = type,
                Date = DateTime.Now,
                InventoryId = product.InventoryId,
            };
            _repo.AddTransaction(transaction);
        }

        public Product GetProduct(int id)
        {
            Product product = _repo.GetById(id);
            if (product == null)
            {
                throw new ProductNotPresentException("Product Not present, provide correct product Id");
            }
            return product;
        }

        public void UpdateDetails(Product product,string name, string description,double price,int inventoryId)
        {
            product.Name = name;
            product.Description = description;
            product.UnitPrice = price;
            product.InventoryId = inventoryId;
            _repo.Update(product);
        }

        public string GetDetails(int id) {
            Product product = GetProduct(id);
            return product.ToString();
        }

        public void Delete(int id)
        {
            Product product = GetProduct(id);
            AddTransaction(product,TypeOfTransactions.Remove);
            _repo.Delete(product);
        }

        public string GetAllDetails()
        {
            List<Product> products = _repo.GetAll();
            if(products.Count == 0)
            {
                throw new NoProductPresentException("No product present!");
            }
            string details = "";
            foreach (Product product in products) {
                details += product.ToString() ;
            }
            return details;
        }
    }
}
