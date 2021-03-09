using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace The_Game_Game__Part_the_First_
{
    static class Technical
    {
        /// <summary>
        /// Returns true if keypress matches parameters, otherwise returns false.
        /// </summary>
        /// <param name="keypress">Keypress to check</param>
        /// <param name="key">Key</param>
        /// <param name="ctrl">If Ctrl is pressed</param>
        /// <param name="alt">If Alt is pressed</param>
        /// <param name="shift">If Shift is pressed</param>
        /// <returns></returns>
        public static bool Keypress(ConsoleKeyInfo keypress, ConsoleKey key, bool ctrl, bool alt, bool shift)
        {
            if (keypress.Key != key)
                return false;
            if (((keypress.Modifiers & ConsoleModifiers.Control) != 0) != ctrl)
                return false;
            if (((keypress.Modifiers & ConsoleModifiers.Alt) != 0) != alt)
                return false;
            if (((keypress.Modifiers & ConsoleModifiers.Shift) != 0) != shift)
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

        public static Random Random = new Random();
    }

    public enum Type
    {
        String,
        Int,
    }
}
