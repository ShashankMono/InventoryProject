using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Controllers
{
    internal interface Controller
    {
        public string GetDetails(int id);
        public void Delete(int id);
        public string GetAllDetails();
    }
}
