using InventoryProject.Exceptions;
using InventoryProject.Models;
using InventoryProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Controllers
{
    internal class SupplierController:Controller
    {
        private SuppliersRepo _repo;

        public SupplierController()
        {
            _repo = new SuppliersRepo();
        }

        public void AddNewSupplier(string name,string contactNumber,int inventoryId)
        {
            Supplier supplier = new Supplier()
            {
                Name = name,
                ContactNumber = contactNumber,
                InventoryId = inventoryId,
            };
            _repo.Add(supplier);
        }

        public Supplier Getsupplier(int id)
        {
            Supplier supplier = _repo.Get(id);
            if (supplier == null)
            {
                throw new supplierNotPresentException("supplier Not present, provide correct supplier Id");
            }
            return supplier;
        }

        public void UpdateDetails(Supplier supplier, string name, string contactNumber,int invetoryId)
        {
            supplier.Name = name;
            supplier.ContactNumber = contactNumber;
            supplier.InventoryId = invetoryId;
            _repo.Update(supplier);
        }

        public string GetDetails(int id)
        {
            Supplier supplier = Getsupplier(id);
            return supplier.ToString();
        }

        public void Delete(int id)
        {
            Supplier supplier = Getsupplier(id);
            _repo.Delete(supplier);
        }

        public string GetAllDetails()
        {
            List<Supplier> suppliers = _repo.GetAll();
            string details = "";
            foreach (Supplier supplier in suppliers)
            {
                details += supplier.ToString();
            }
            return details;
        }
    }
}
