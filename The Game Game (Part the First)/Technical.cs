using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace The_Game_Game__Part_the_First_
{
    static class Technical
    {
        public static bool Matches(this ConsoleKeyInfo keypress, ConsoleKey key, bool? ctrl, bool? alt, bool? shift)
        {
            if (keypress.Key != key)
                return false;

            if (ctrl.HasValue)
                if ((keypress.Modifiers & ConsoleModifiers.Control) != 0 != ctrl.Value)
                    return false;

            if (alt.HasValue)
                if ((keypress.Modifiers & ConsoleModifiers.Alt) != 0 != alt.Value)
                    return false;
            
            if (shift.HasValue)
                if ((keypress.Modifiers & ConsoleModifiers.Shift) != 0 != shift.Value)
                    return false;

            return true;
        }

        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        public static bool Chance(this double chance)
        {
            return Random.NextDouble() <= chance;
        }

        public static T GetRandom<T>(this List<T> list, out int index)
        {
            index = Random.Next(0, list.Count);
            return list[index];
        }

        public static T GetRandom<T>(this List<T> list)
        {
            return GetRandom(list, out _);
        }

        public static Random Random = new Random();
    }

    public enum Type
    {
        String,
        Int,
    }
}
