using InventoryProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Controllers
{
    internal class InventoryController
    {
        InventoryRepo _repo;
        public InventoryController()
        {
            _repo = new InventoryRepo();
        }

        public string GetAllReport()
        {
            string Report = "";
            _repo.InventoriesReport().ForEach((inventory) =>
            {
                Report += inventory.ToString();
                inventory.Transactions.ForEach((Transaction) =>
                {
                    Report += Transaction.ToString();
                    Transaction.Inventory.Suppliers.ForEach((product) => {
                        Report += product.ToString();
                        //supplier.Inventory.Transactions.ForEach((transaction) => { 
                        //    Report = transaction.ToString();
                        //});
                    });
                });
            });
            return Report;
        }
    }
}
