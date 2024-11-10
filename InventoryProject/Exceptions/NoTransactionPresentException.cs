using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Exceptions
{
    internal class NoTransactionPresentException:Exception
    {
        public NoTransactionPresentException(string message):base(message) { }
    }
}
