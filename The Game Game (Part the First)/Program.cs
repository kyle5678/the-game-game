using System;
using System.IO;

namespace The_Game_Game__Part_the_First_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Welcome();
                GameGame();
            }

            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Sorry, an error occurred (which may or may not be your fault). Below is some information (which no doubt you won't understand, so send it to the developers)");
                Console.WriteLine(e);
                File.WriteAllText($"{Directory.GetCurrentDirectory()}/exception.txt", e.ToString());
                Console.WriteLine("Now go away.");
            }

            finally
            {
                Console.ReadKey();
                Console.Clear();

                Text.Center(1);
                Text.Center("Program has ended. Press any key to continue.");

                Console.ReadKey();
            }
        }

        public static void Welcome()
        {
            Text.Center(5);
            Text.Center("Welcome to the Game Game!");
            Text.Center("(terms and conditions apply (don't steal the code))");
            Text.Blank(2);
            Text.Center("press any key to START");

            ConsoleKeyInfo keypress = Console.ReadKey(true);
            Console.Clear();
            if (Technical.Keypress(keypress, ConsoleKey.G, true, true, true))
            {
                Text.Center(2);
                Text.Center("How did you find out the secret code?");
                Text.Center("We told the developers not to leak it!");
                Game.ActivateSecretDeveloperMode();
                Console.ReadKey();
                Console.Clear();
            }

            //Console.WriteLine("Select Gamemode:\n\t1. singleplayer\n\t2. multiplayer");
            //while (true)
            //{
            //    keypress = Console.ReadKey(true);
            //    if (keypress.Key == ConsoleKey.D1)
            //    {
            Console.WriteLine("Gamemode selected: Singleplayer");
            //Game.Players.Add(
            Game.PlayerOne = new Player(Text.Input("What shall you be called in this world?", "You can't have no name! Have another try."), 10);

            //        break;
            //    }

            //    if (keypress.Key == ConsoleKey.D2)
            //    {
            //        Console.WriteLine("Gamemode selected: Multiplayer");
            //        int players = Text.Input("How many players? ", 0, "that isn't a number. ");
            //        for (int i = 0; i < players; i++)
            //        {
            //            Game.Players.Add(new Player(
            //                Text.Input($"Please name Player #{i + 1}", "Make a name already, would you?"), 10));
            //        }

            //        break;
            //    }
            //}

            Console.WriteLine("Okay! You're all set to begin your journey! Have fun!");
            Text.Wait();
        }

        public static void GameGame()
        {
            Story.Storytell(StoryArc.Chapter1);
        }
    }
}
