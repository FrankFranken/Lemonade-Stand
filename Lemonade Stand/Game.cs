using Lemonade_Stand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Game
    {
        Player player;
        Day day;      
        public Game()
        {
            player = new Player();
            day = new Day();
        }
        public void RunGame()
        {       
            Rules();
            player.NewPlayer();
            for (int i = 0; i < 7; i++)
            {
                day.PrintForcast(i);
                day.weather.DailyForcast();                
                player.BuyItems(player);
                player.inventory.ShowAllProductInventory();
                player.recipe.pitcher.SetIngredients();
                player.recipe.CreatePitchers(player);
                day.PrintDay(i);
                day.weather.DailyCondition();
                day.weather.customer.CustomerConditions(day.weather);
                day.weather.customer.BuyLemonade(player.inventory, player.recipe.pitcher, player.recipe, player.wallet);
            }
            EndGame();
        }
        public void Rules()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(">>>>>>>>>>>>>>>>>>LEMONADE STAND<<<<<<<<<<<<<<<<<<<<");
            Console.ResetColor();
            Console.WriteLine("\nRules:");           
            Console.WriteLine("Your job is to sell as much lemonade as possible.");
            Console.WriteLine("Be sure to factor in the weather and provide high quality Lemonade.");
            Console.WriteLine("Before each day you will have an option buy supplies.");
            Console.WriteLine("See if you can make it through 7 days \n \t Goodluck\n");
        }
        public void EndGame()
        {
            Console.WriteLine("\nCongratulations you made it through all 7 days!!!");
            Console.WriteLine("You are a Lemonade stand champion.");
            Console.WriteLine("\nWould you like to play again?");
            Console.WriteLine("yes or no");
            string decision = Console.ReadLine().ToLower();
            switch (decision)
            {
                case "yes":
                    RunGame();
                    break;
                case "no":
                    Console.WriteLine("\nThanks for playing");
                    System.Environment.Exit(0);
                    break;
            }          
        }   
    }     
}

