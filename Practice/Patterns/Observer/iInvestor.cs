using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Patterns.Observer
{
    interface IInvestor
    {
        void Update(Stock s);
    }
}
