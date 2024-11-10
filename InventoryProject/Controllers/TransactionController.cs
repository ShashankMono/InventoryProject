using InventoryProject.Models;
using InventoryProject.Repositories;
using InventoryProject.TypeOfTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Controllers
{
    internal class TransactionController
    {
        private TransactionRepo _transactionRepo;
        private ProductController _productController;

        public TransactionController()
        {
            _transactionRepo = new TransactionRepo();
            _productController = new ProductController();
        }

        public void ChangeStock(Product product, int quantity,TypeOfTransactions type)
        {
            Transaction transaction = new Transaction()
            {
                ProductId = product.ProductId,
                Quantity = quantity,
                Type = type,
                Date = DateTime.Now,
                InventoryId = product.InventoryId,
            };
            if(type == TypeOfTransactions.Add)
            {
                product.Quantity += quantity;
            }
            else
            {
                product.Quantity -= quantity;
            }
            
            _transactionRepo.ManipulateStock(product, transaction);
        }

        public string GetAllTransaction()
        {
            string transactionHistory = "";
            _transactionRepo.GetAll().ForEach((t) =>
            {
                transactionHistory += t.ToString();
            });
            return transactionHistory;
        }

    }
}
