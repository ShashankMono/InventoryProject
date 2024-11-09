using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Models
{
    internal class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        //Navigation
        public Inventory Inventory { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }


        public override string ToString()
        {
            return $"Product Id : {ProductId}\n" +
                $"Name : {Name}\n" +
                $"Description : {Description}\n" +
                $"Quantity : {Quantity}\n" +
                $"UnitPrice : {UnitPrice}\n" +
                $"=====================================\n";
        }
    }
}
