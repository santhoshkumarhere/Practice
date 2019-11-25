using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Patterns.Observer
{
    class Investor: IInvestor
    {
        private readonly string name;

        public Investor(string name)
        {
            this.name = name;
        }

        public void Update(Stock s)
        {
            Console.WriteLine("Notified {0} of {1}'s " +
                              "change to {2:C}", name, s.Symbol, s.Price);
        }

        public Stock Stock { get; set; }
    }
}
