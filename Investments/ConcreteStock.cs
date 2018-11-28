using System;
using System.Collections.Generic;
using System.Text;

namespace Investments
{
    public class ConcreteStock : Stock
    {
        // Constructor
        public ConcreteStock(string symbol, double price)
          : base(symbol, price) { }
    }
}
