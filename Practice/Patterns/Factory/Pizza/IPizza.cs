using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Patterns.Factory
{
    public interface IPizza
    {
        void Prepare();
        void Bake();
        void Cut();
        void Box();
    }
}
