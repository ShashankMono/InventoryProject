using InventoryProject.Data;
using InventoryProject.Exceptions;
using InventoryProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Repositories
{
    internal class ProductRepo
    {
        private InventoryContext _context;

        public ProductRepo()
        {
            _context = new InventoryContext();
        }

        public void Add(Product product)
        {
            Product checkIsProductPresent = _context.Products.Where(p => p.Name.ToLower() == product.Name.ToLower()).FirstOrDefault();
            if (checkIsProductPresent != null)
            {
                throw new ProductAllreadyPresentException("Product Allready present!");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product) {

            _context.Products.Entry(product).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void Delete(Product product) { 
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product GetById(int id)
        {
            return _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }

        public Product GetByName(string name)
        {
            return _context.Products.Where(p => p.Name == name).FirstOrDefault();
        }

        public List<Product> GetAll() { 
            return _context.Products.ToList();
        }

        public void AddFirstTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
    }
}
