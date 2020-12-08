using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSimpleRestaurant
{
    abstract class Item : IOrderable
    {
        public string Name { get; }
        public int Popularity { get; }
        public abstract void Order(int times);
    }
}
