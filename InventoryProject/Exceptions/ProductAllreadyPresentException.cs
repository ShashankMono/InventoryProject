﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Exceptions
{
    internal class ProductAllreadyPresentException:Exception
    {
        public ProductAllreadyPresentException(string message):base(message) { }
    }
}
