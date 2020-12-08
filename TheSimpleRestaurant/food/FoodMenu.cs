using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSimpleRestaurant
{
    class FoodMenu : IMenu<Item>
    {
        private readonly int highlightSectionSize;
        private readonly List<Dish> dishes;

        public string Name { get; }

        public FoodMenu(string name, List<Dish> menuItems, int highlightSectionSize)
        {
            Name = name;
            dishes = menuItems;
            this.highlightSectionSize = highlightSectionSize;
        }

        public static List<Dish> GetMockedItems()
        {
            return new List<Dish>() { 
                new Dish("croissant", new List<Ingredient>() { 
                    new Ingredient("butter", Ingredient.FoodType.DAIRY, 200),
                    new Ingredient("flour", Ingredient.FoodType.GRAIN, 50),
                    new Ingredient("sugar", Ingredient.FoodType.OTHER, 60),
                }),
                new Dish("caffe latte", new List<Ingredient>() {
                    new Ingredient("milk", Ingredient.FoodType.DAIRY, 30),
                    new Ingredient("coffee", Ingredient.FoodType.FRUIT, 10),
                    new Ingredient("sugar", Ingredient.FoodType.OTHER, 60),
                }),
                new Dish("salmon sushi", new List<Ingredient>() {
                    new Ingredient("salmon", Ingredient.FoodType.PROTEIN, 50),
                    new Ingredient("rice", Ingredient.FoodType.GRAIN, 50),
                    new Ingredient("wakame", Ingredient.FoodType.VEGETABLE, 50),
                }),
                new Dish("curry", new List<Ingredient>() {
                    new Ingredient("vegetables", Ingredient.FoodType.VEGETABLE, 50),
                    new Ingredient("rice", Ingredient.FoodType.GRAIN, 50),
                    new Ingredient("sause", Ingredient.FoodType.OTHER, 150),
                }),
                new Dish("soup", new List<Ingredient>() {
                    new Ingredient("water", Ingredient.FoodType.DRINK, 50),
                    new Ingredient("rice", Ingredient.FoodType.GRAIN, 50),
                    new Ingredient("chicken", Ingredient.FoodType.PROTEIN, 50),
                })
            };
        }

        public void PrintHighlightedItems()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine($"**This are the highlighted dishes for today!**");

            List<Dish> highlightDishes = GetDishesWithLessThan300CaloriesSortedByPopularity();

            for (int i = 0; i < highlightSectionSize && i < highlightDishes.Count(); i++)
            {
                Console.WriteLine($" - {highlightDishes[i]}");
            }

            Console.WriteLine("***************************************************");
        }

        public void PrintAllItems()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"This are all the dishes we offer:");

            foreach (Item item in dishes) Console.WriteLine($" - {item}");

            Console.WriteLine("--------------------------------------");
        }

        public Item GetItem(string name)
        {
            return dishes.Find(dish => name.Equals(dish.Name));
        }

        public bool HasItem(string name)
        {
            return dishes.FindIndex(dish => name.Equals(dish.Name)) > -1;
        }

        private List<Dish> GetDishesWithLessThan300CaloriesSortedByPopularity()
        {
            List<Dish> lowCalorieFoods = dishes.FindAll(item => item.CountCalories() < 300);

            return lowCalorieFoods
                .OrderByDescending(item => item.Popularity)
                .ThenBy(item => item.CountCalories())
                .ToList();
        }
    }
}