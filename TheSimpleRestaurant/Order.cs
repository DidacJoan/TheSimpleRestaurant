using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSimpleRestaurant
{
    class Order : IOrder<string>
    {
        private readonly IMenu<Item> menu;
        private readonly IDictionary<string, int> itemAmountsByName;
        
        private bool processed = false;

        public Order(IMenu<Item> menu) 
        {
            this.menu = menu;

            itemAmountsByName = new Dictionary<string, int>();
        }

        public void AddItem(string itemName)
        {
            if (!menu.HasItem(itemName))
            {
                Console.WriteLine($"Sorry, we couldn't find any item with the name {itemName} in our menu");
                return;
            }

            itemAmountsByName[itemName] = itemAmountsByName.ContainsKey(itemName) 
                ? itemAmountsByName[itemName] + 1 
                : 1;

            Console.WriteLine($"1 {itemName} has been added");
        }

        public void RemoveItem(string itemName)
        {
            if (!itemAmountsByName.ContainsKey(itemName))
            {
                Console.WriteLine($"no {itemName} has been ordered");
                return;
            }

            itemAmountsByName[itemName] -= 1;

            if (itemAmountsByName[itemName] == 0) itemAmountsByName.Remove(itemName);

            Console.WriteLine($"1 {itemName} has been removed");
        }

        public void Process()
        {
            foreach (string itemName in itemAmountsByName.Keys)
            {
                menu.GetItem(itemName).Order(itemAmountsByName[itemName]);
            }

            Console.WriteLine($"Order has been processed");
            processed = true;
        }

        public bool IsProcessed()
        {
            return processed;
        }

        override
        public string ToString()
        {
            if (itemAmountsByName.Count() == 0) return "Your order is empty";

            string stringifiedOrder = "";

            foreach (string itemName in itemAmountsByName.Keys)
            {
                stringifiedOrder += $"Item {itemName} : {itemAmountsByName[itemName]} units \n";
            }

            return stringifiedOrder;
        }
    }
}
