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

        public void AddStock(int id)
        {

            Product product = _productRepo.Get(id);


        }


    }
}
