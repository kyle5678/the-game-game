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

        public static void Blank(int lines = 1)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }

        public static void Line()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
        }

        public static void Wait()
        {
            Console.ReadKey(true);
        }

        public static void Wait(object text)
        {
            Console.WriteLine(text);
            Console.ReadKey(true);
        }

        public static void Wait(params object[] text)
        {
            foreach (object print in text)
            {
                Wait(print);
            }
        }

        public static void Wait(object text, string split)
        {
            string[] art = text.ToString().Split(split);
            foreach (string arts in art)
            {
                Wait(arts);
            }
        }

        public static int InputNumber(int max)
        {
            return InputNumber(max, out _).Value;
        }

        public static int? InputNumber(int max, out ConsoleKey outKey, bool allowZero, params ConsoleKey?[] allowedKeys)
        {
            while (true)
            {
                ConsoleKeyInfo keypress = Console.ReadKey(true);
                ConsoleKey key = keypress.Key;
                outKey = key;

                if (Array.Exists(allowedKeys, element => element == key))
                {
                    return null;
                }

                else if (int.TryParse(keypress.KeyChar.ToString(), out int index))
                {
                    if (index <= max && index != 0 || allowZero)
                    {
                        return index;
                    }
                }
            }
        }

        public static int? InputNumber(int max, out ConsoleKey outKey, params ConsoleKey?[] allowedKeys)
        {
            return InputNumber(max, out outKey, false, allowedKeys);
        }

        public static int Choose(string message, params string[] choices)
        {
            Console.WriteLine(message);
            foreach (string choice in choices)
            {
                Console.WriteLine($"\t{Array.IndexOf(choices, choice) + 1}. {choice}");
            }

            return InputNumber(choices.Length + 1);
        }

        public static int? Select(string message, bool canEscape, params string[] choices)
        {
            int tensAdd = 0;
            while (true)
            {
                Console.WriteLine($"{message} ({tensAdd+1}/{choices.Length})");
                for (int i = 0; i < 10; i++)
                {
                    if (i + tensAdd < choices.Length)
                        Console.WriteLine($"\t({(i == 10 ? 0 : i + 1)}) {choices[i + tensAdd]} ({i + tensAdd + 1})");
                }

                int? chosen;
                ConsoleKey key;
                if (choices.Length - tensAdd < 10)
                {
                    chosen = InputNumber(choices.Length - tensAdd, out key, ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.Escape);
                }

                else
                {
                    chosen = InputNumber(9, out key, true, ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.Escape);
                }

                if (chosen.HasValue)
                {
                    if (chosen == 0)
                        chosen = 10;

                    int index = tensAdd + (int)chosen;
                    //Console.WriteLine($"You chose {index}, /*which*/ was {choices[index - 1]}");
                    return index - 1;
                }

                else if (key == ConsoleKey.LeftArrow && tensAdd > 0)
                {
                    tensAdd -= 10;
                }

                else if (key == ConsoleKey.RightArrow && tensAdd + 10 < choices.Length)
                {
                    tensAdd += 10;
                }

                else if (key == ConsoleKey.Escape)
                {
                    if (canEscape)
                        return null;
                    else
                        Wait("You cannot skip this selection.");
                }
            }
        }

        public static int Select(string message, params string[] choices)
        {
            return (int)Select(message, false, choices);
        }

        public static int? Select(string message, bool canEscape, params object[] choices)
        {
            List<string> selectionStrings = new List<string>();
            foreach (object thing in choices)
            {
                if (thing is string unchanged)
                    selectionStrings.Add(unchanged);
                else if (thing is Enemy foe)
                    selectionStrings.Add(foe.Name);
                else if (thing is Item item)
                    selectionStrings.Add(item.Name);
                else if (thing is Weapon weapon)
                    selectionStrings.Add(weapon.Name);
                else if (thing is AttackMove attack)
                    selectionStrings.Add(attack.Type.ToString());
                else if (thing is Room room)
                    selectionStrings.Add(room.EntryDescription);
                else
                    selectionStrings.Add($"{thing} of type {thing.GetType()}");
            }

            return Select(message, canEscape, selectionStrings.ToArray());
        }

        public static int Select(string message, params object[] choices)
        {
            return (int)Select(message, false, choices);
        }
    }
}