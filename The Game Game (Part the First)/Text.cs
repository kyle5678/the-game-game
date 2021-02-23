using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    static class Text
    {
        public static void Center(string text)
        {
            int width = Console.WindowWidth;
            int textlen = text.Length;

            for (int i = 0; i < (width - textlen) / 2; i++)
            {
                Console.Write(" ");
            }

            Console.WriteLine(text);
        }

        public static void Center(int lines)
        {
            int height = Console.WindowHeight;

            for (int i = 0; i < (height - lines) / 2; i++)
            {
                Console.WriteLine();
            }
        }

        public static string Input(string text)
        {
            Console.Write($"{text} ");
            return Console.ReadLine();
        }

        public static string Input(string text, string emptyMessage)
        {
            Console.Write($"{text} ");
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Write($"{emptyMessage} ");
                }

                else
                {
                    return input;
                }
            }
        }

        public static int Input(string text, int type, string unIntMessage)
        {
            Console.Write($"{text} ");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int n))
                {
                    return n;
                }

                else
                {
                    Console.Write($"{unIntMessage} ");
                }
            }
        }

        public static void Blank(int lines = 1)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }

        public static void Wait()
        {
            Console.ReadKey(true);
        }

        public static void Wait(string text)
        {
            Console.WriteLine(text);
            Console.ReadKey(true);
        }

        public static int InputNumber(int max)
        {
            while (true)
            {
                ConsoleKeyInfo keypress = Console.ReadKey(true);
                if (int.TryParse(keypress.KeyChar.ToString(), out int index))
                {
                    if (index <= max)
                    {
                        return index;
                    }
                }
            }
        }
    }
}