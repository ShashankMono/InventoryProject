using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Models
{
    internal class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }

        //Navigation
        public Inventory Inventory { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryId  { get; set; }


        public override string ToString()
        {
            return $"Supplier Id : {SupplierId}\n" +
                $"Name : {Name}\n" +
                $"Constact Number : {ContactNumber}\n" +
                $"Inventory Id : {InventoryId}\n" +
                $"==========================================\n";
        }
    }
}
