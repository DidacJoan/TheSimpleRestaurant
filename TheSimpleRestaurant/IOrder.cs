using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSimpleRestaurant
{
    interface IOrder<T>
    {
        void AddItem(T item);
        void RemoveItem(T item);
        void Process();
        bool IsProcessed();
    }
}
