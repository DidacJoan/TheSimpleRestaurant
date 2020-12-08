using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSimpleRestaurant
{
    interface IMenu<T>
    {
        string Name { get; }

        void PrintHighlightedItems();
        void PrintAllItems();
        T GetItem(string name);
        bool HasItem(string name);
    }
}