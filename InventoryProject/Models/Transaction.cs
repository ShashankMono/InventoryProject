using InventoryProject.TypeOfTransaction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Models
{
    internal class Transaction
    {
        public int TransactionId { get; set; }
        //Navigation to product
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId    { get; set; }
        public TypeOfTransactions Type {  get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        //navigation to inventory
        public Inventory Inventory {  get; set; }
        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }


        public override string ToString()
        {
            return $"Transaction Id : {TransactionId}\n" +
                $"Product Id : {ProductId}\n" +
                $"Type : {Type.ToString()}\n" +
                $"Quantity : {Quantity}\n" +
                $"Date : {Date}\n" +
                $"Inventory Id : {InventoryId}\n";
        }

    }
}
