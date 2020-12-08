using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSimpleRestaurant
{
    class Dish : Item, IDigestible
    {
        private readonly List<Ingredient> ingredients;

        public new string Name
        {
            get;
        }

        public new int Popularity
        {
            get; private set;
        }

        public Dish(string name, List<Ingredient> ingredients)
        {
            Name = name;
            this.ingredients = ingredients;

            Popularity = 0;
        }

        override
        public void Order(int times)
        {
            Popularity += times;

            Console.WriteLine($"{Name} has been ordered {times} times!");
        }

        public int CountCalories()
        {
            int totalCalories = 0;

            foreach (Ingredient ingredient in ingredients)
            {
                totalCalories += ingredient.CountCalories();
            }

            return totalCalories;
        }

        public bool IsEasyToDigest()
        {
            return ingredients.TrueForAll(ingredient => ingredient.IsEasyToDigest());
        }

        override
        public string ToString()
        {
            string stringifiedIngredients 
                = String.Join(", ", ingredients.Select(ingredient => ingredient.Name).ToList());

            return $"Item: {Name}, Popularity: {Popularity}, Calories: {CountCalories()}, " +
                $"\n\tIngredients: {stringifiedIngredients}" +
                $"{(IsEasyToDigest() ? ", Note: easy to digest!" : "")}";
        }
    }
}
