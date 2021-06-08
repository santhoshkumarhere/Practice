using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Patterns.Factory
{
    public abstract class PizzaStore : IPizzaStore
    {
        public IPizza OrderPizza(string type)
        {
            var pizza = CreatePizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            
            return pizza;
        }

        public abstract IPizza CreatePizza(string type); 
    }
}
