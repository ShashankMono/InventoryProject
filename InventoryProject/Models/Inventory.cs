using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Models
{
    internal class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public string Location { get; set; }

        //Navigation
        public List<Product> Products { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Transaction> Transactions { get; set; }

        public override string ToString()
        {
            return $"Inventory Id: {InventoryId}\n" +
                $"Location : {Location}\n" +
                $"======================================\n";
        }
    }
}
