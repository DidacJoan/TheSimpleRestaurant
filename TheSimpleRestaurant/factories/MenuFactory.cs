using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSimpleRestaurant
{
    static class MenuFactory
    {
        public enum Type
        {
            FOOD,
            BOARD_GAMES
        }

        public static IMenu<Item> GetMenu(Type type)
        {
            return type switch
            {
                Type.FOOD 
                    => new FoodMenu("Delicious food menu", FoodMenu.GetMockedItems(), 3) 
                    as IMenu<Item>,
                Type.BOARD_GAMES 
                    => new BoardGamesMenu("Fun board games menu", BoardGamesMenu.GetMockedItems(), 2) 
                    as IMenu<Item>,
                _ => null,
            };
        }
    }
}
