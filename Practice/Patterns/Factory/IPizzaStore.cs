using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Patterns.Factory
{
    interface IPizzaStore
    {
       IPizza OrderPizza(string type);
    }
}
