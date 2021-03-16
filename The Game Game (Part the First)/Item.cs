using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    public enum ItemUse
    {
        Heal
    }

    class Item
    {
        public Item()
        {

        }

        public Item(string name, ItemUse use, int value, bool isInfinite = false)
        {
            Name = name;
            Use = use;
            Value = value;
            Infinite = isInfinite;
        }

        public bool UseItem()
        {
            if (Use == ItemUse.Heal)
            {
                if (Game.PlayerOne.CurrentHealth == Game.PlayerOne.MaxHealth)
                {
                    Text.Wait("You can't use this item right now!");
                    return false;
                }

                else
                {
                    Game.PlayerOne.CurrentHealth += Value;
                }
            }

            if (!Infinite)
            {
                Game.PlayerOne.Items.Remove(this);
            }

            return true;
        }

        public string Name;
        public bool Infinite = false;
        public ItemUse Use;
        public int Value;
    }
}
