using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSimpleRestaurant
{
    class BoardGamesMenu : IMenu<Item>
    {
        private readonly int highlightSectionSize;
        private readonly List<BoardGame> boardGames;

        public string Name { get; }

        public BoardGamesMenu(string name, List<BoardGame> menuItems, int highlightSectionSize)
        {
            Name = name;
            boardGames = menuItems;
            this.highlightSectionSize = highlightSectionSize;
        }

        public static List<BoardGame> GetMockedItems()
        {
            return new List<BoardGame>() { 
                new BoardGame("Monopoly", DateTime.Parse("1932-03-19")),
                new BoardGame("The Settlers of Catan", DateTime.Parse("1995-01-01")),
                new BoardGame("Trivial Pursuit", DateTime.Parse("1979-12-15"))
            };
        }

        public void PrintHighlightedItems()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine($"**This are the highlighted board games for today!**");

            List<BoardGame> highlightBoardGames = GetBoardGamesOrderedByLatestReleaseDate();

            for (int i = 0; i < highlightSectionSize && i < highlightBoardGames.Count(); i++)
            {
                Console.WriteLine($" - {highlightBoardGames[i]}");
            }

            Console.WriteLine("***************************************************");
        }

        public void PrintAllItems()
        {
            Console.WriteLine($"This are all the games we offer:");

            foreach (Item item in boardGames) Console.WriteLine($" - {item}");

            Console.WriteLine("-----------------------------");
        }

        public Item GetItem(string name)
        {
            return boardGames.Find(boardGame => name.Equals(boardGame.Name));
        }

        public bool HasItem(string name)
        {
            return boardGames.FindIndex(boardGame => name.Equals(boardGame.Name)) > -1;
        }

        private List<BoardGame> GetBoardGamesOrderedByLatestReleaseDate()
        {
            return boardGames
                .OrderByDescending(boardGame => boardGame.ReleaseDate)
                .ToList();
        }
    }
}