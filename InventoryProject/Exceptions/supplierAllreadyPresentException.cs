using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Exceptions
{
    internal class supplierAllreadyPresentException:Exception
    {
        public supplierAllreadyPresentException(string message) : base(message) { }
    }
}
