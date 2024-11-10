using InventoryProject.Data;
using InventoryProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Repositories
{
    internal class InventoryRepo
    {
        private InventoryContext _context;

        public InventoryRepo()
        {
            _context = new InventoryContext();
        }

        public List<Inventory> InventoriesReport()
        {
            return _context.inventories.Include(i=> i.Transactions)
                .ThenInclude(i=> i.Product).ToList();
        }
    }
}
