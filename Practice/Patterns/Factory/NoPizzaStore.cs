using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Patterns.Factory
{
    public class NoPizzaStore : IPizzaStore
    {
        public IPizza OrderPizza(string type)
        {
            throw new NotImplementedException();
        }
    }
}
