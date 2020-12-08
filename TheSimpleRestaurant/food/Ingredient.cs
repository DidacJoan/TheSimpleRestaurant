using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSimpleRestaurant
{
    class Ingredient : IDigestible
    {
        public enum FoodType
        {
            DRINK,
            PROTEIN,
            VEGETABLE,
            FRUIT,
            GRAIN,
            DAIRY,
            OTHER
        }

        private readonly int calories;

        public string Name
        {
            get; set;
        }

        private FoodType Type 
        {
            get; set;
        }

        public Ingredient(string name, FoodType type, int calories)
        {
            Name = name;
            Type = type;
            this.calories = calories;
        }

        public int CountCalories()
        {
            return calories;
        }

        public bool IsEasyToDigest()
        {
            return !Type.Equals(FoodType.DAIRY);
        }
    }
}
