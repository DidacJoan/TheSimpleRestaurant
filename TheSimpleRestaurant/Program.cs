using System;

namespace TheSimpleRestaurant
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the simple restaurant! What do you want to do?");

            ExecuteMenu(MenuFactory.GetMenu(MenuFactory.Type.FOOD));

            Console.WriteLine("We offer a rental service of board games, do you want to make use of it? (y/n)");
            
            if (Console.ReadLine().Equals("y"))
            {
                ExecuteMenu(MenuFactory.GetMenu(MenuFactory.Type.BOARD_GAMES));
            }

            Console.WriteLine("Thank you, We will bring your requested items as soon as possible!");
        }


        private static void ExecuteMenu(IMenu<Item> menu)
        {
            IOrder<string> order = new Order(menu);

            menu.PrintHighlightedItems();

            while (!order.IsProcessed())
            {
                Console.WriteLine();
                Console.WriteLine($" {menu.Name}:");
                Console.WriteLine(" 0 - see the menu");
                Console.WriteLine(" 1 - add item to order ");
                Console.WriteLine(" 2 - remove item from order");
                Console.WriteLine(" 3 - see order status");
                Console.WriteLine(" 4 - finish order");

                switch (Console.ReadLine())
                {
                    case "0":
                        menu.PrintAllItems();
                        break;

                    case "1":
                        Console.WriteLine("What do you want to add to the order?");
                        order.AddItem(Console.ReadLine());
                        break;

                    case "2":
                        Console.WriteLine("What do you want to remove from the order?");
                        order.RemoveItem(Console.ReadLine());
                        break;

                    case "3":
                        Console.WriteLine("This is the status of your order:");
                        Console.WriteLine(order);
                        break;

                    case "4":
                        Console.WriteLine("Processing order...");
                        order.Process();
                        break;

                    default:
                        Console.WriteLine("Please, enter one of the menu options");
                        break;
                }
            }
        }
    }
}
