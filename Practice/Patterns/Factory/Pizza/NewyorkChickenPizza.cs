using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Patterns.Factory
{
    class NewyorkChickenPizza: IPizza
    {
        public void Bake()
        {
            Console.WriteLine("Baking NewyorkChickenPizza..!");
        }

        public void Box()
        {
            Console.WriteLine("Boxing NewyorkChickenPizza..!");
        }

        public void Cut()
        {
            Console.WriteLine("Cutting NewyorkChickenPizza..!");
        }

        public void Prepare()
        {
            Console.WriteLine("Preparing NewyorkChickenPizza..!");
        }
    }
}
