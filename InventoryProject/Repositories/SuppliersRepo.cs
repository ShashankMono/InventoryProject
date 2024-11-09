using InventoryProject.Data;
using InventoryProject.Exceptions;
using InventoryProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Repositories
{
    internal class SuppliersRepo
    {
        private InventoryContext _context;

        public SuppliersRepo()
        {
            _context = new InventoryContext();
        }

        public void Add(Supplier supplier)
        {
            Supplier checkIssupplierPresent = _context.Suppliers.Where(p => p.Name.ToLower() == supplier.Name.ToLower()).FirstOrDefault();
            if (checkIssupplierPresent != null)
            {
                throw new supplierAllreadyPresentException("supplier Allready present!");
            }
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void Update(Supplier supplier)
        {

            _context.Suppliers.Entry(supplier).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void Delete(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }

        public Supplier Get(int id)
        {
            return _context.Suppliers.Where(p => p.SupplierId == id).FirstOrDefault();
        }

        public List<Supplier> GetAll()
        {
            return _context.Suppliers.ToList();
        }
    }
}
