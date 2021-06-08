using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Patterns.Factory
{
    public class NewyorkPizzaStore : PizzaStore
    {
        public override IPizza CreatePizza(string type)
        {
            if(type.Equals("chicken", StringComparison.InvariantCultureIgnoreCase))
            {
                return new NewyorkChickenPizza();
            }

            if (type.Equals("cheese", StringComparison.InvariantCultureIgnoreCase))
            {
                return new NewyorkCheesePizza();
            }

            return null;
        }
    }
}
