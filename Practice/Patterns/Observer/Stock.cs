using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Patterns.Observer
{
    internal abstract class Stock
    {
        private decimal price;
        private readonly List<IInvestor> investors = new List<IInvestor>();

        protected Stock(string symbol, decimal price)
        {
            this.price = price;
            this.Symbol = symbol;
        }

        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (var investor in investors)
            {
                investor.Update(this);
            }
        }

        public decimal Price
        {
            get => this.price;
            set
            {
                if (price == value) return;

                price = value;
                Notify();
            }
        }

        public string Symbol { get; }
    }

    internal class IBM : Stock
    {
        public IBM(string symbol, decimal price)
            : base(symbol, price)
        {
        }
    }
}
