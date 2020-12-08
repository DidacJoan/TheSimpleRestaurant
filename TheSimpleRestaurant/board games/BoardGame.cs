using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSimpleRestaurant
{
    class BoardGame : Item
    {
        public new string Name
        {
            get;
        }

        public DateTime ReleaseDate
        {
            get;
        }

        public BoardGame(string name, DateTime releaseDate)
        {
            this.Name = name;
            this.ReleaseDate = releaseDate;
        }

        override
        public void Order(int times)
        {
            Console.WriteLine($"{Name} has been ordered {times} times!");
        }

        override
        public string ToString()
        {
            return $"Item: {Name}, ReleaseDate: {ReleaseDate.Date}, Popularity: {Popularity}";
        }
    }
}
