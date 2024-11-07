using InventoryProject.Data;
using InventoryProject.Models;
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
            Product checkIsProductPresent = _context.Products.Where(p=> p.Name == product.Name ).FirstOrDefault();
            if(checkIsProductPresent == null)
            {

            }
        }
    }
}
