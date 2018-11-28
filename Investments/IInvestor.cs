using System;
using System.Collections.Generic;
using System.Text;

namespace Investments
{
    public interface IInvestor
    {
        void Update(Stock stock);
        string GetName();
    }
}
