using InventoryProject.Data;
using InventoryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Repositories
{
    internal class TransactionRepo:Exception
    {
        private InventoryContext _context;
        private ProductRepo _productRepo;

        public TransactionRepo()
        {
            _context = new InventoryContext();
            _productRepo = new ProductRepo();
        }

        public void ManipulateStock(Product product,Transaction transaction)
        {
            _productRepo.Update(product);
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            
        }

        public List<Transaction> GetAll()
        {
            return _context.Transactions.ToList();
        }
    }
}
