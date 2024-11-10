using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Exceptions
{
    internal class NoProductPresentException:Exception
    {
        public NoProductPresentException(string message):base(message) { }
    }
}
