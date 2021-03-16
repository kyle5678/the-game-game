using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    class Room
    {
        public Room()
        {

        }

        public Room(params object[] contents)
        {
            Add(contents);
        }

        public void Add(params object[] contents)
        {
            foreach (object thing in contents)
            {
                if (thing is Enemy enemy)
                {
                    Encounters.Add(enemy);
                }

                else if (thing is Item item)
                {
                    Items.Add(item);
                }

                else if (thing is Weapon weapon)
                {
                    Weapons.Add(weapon);
                }

                else
                {
                    Console.WriteLine("// DEBUG : parameter must be in type Enemy, Item, or Weapon");
                }
            }
        }

        public List<Enemy> Encounters = new List<Enemy>();
        public List<Item> Items = new List<Item>();
        public List<Weapon> Weapons = new List<Weapon>();
        public List<Room> Exits = new List<Room>();

        public void EnterRoom()
        {
            if (Encounters.Count > 0)
            {
                Text.Wait("Upon entering the room, you see foes.");
                Combat.Start(Encounters.ToArray());
            }

            if (Items.Count > 0 || Weapons.Count > 0)
            {
                Text.Wait("You see various items littered on the ground.");
                List<object> Loot = new List<object>();
                Loot.AddRange(Items);
                Loot.AddRange(Weapons);

                while (true)
                {
                    if (Loot.Count == 0)
                    {
                        Text.Wait("There are no more items to pick up.");
                        break;
                    }

                    int? objectIndex = Text.Select("a", true, Loot.ToArray());

                    if (objectIndex.HasValue)
                    {
                        object pickup = Loot[objectIndex.Value];
                        if (pickup is Item item)
                        {
                            Game.PlayerOne.Items.Add(item);
                            Text.Wait($"You pick up the {item.Name}.");
                        }

                        else if (pickup is Weapon weapon)
                        {
                            Game.PlayerOne.Weapons.Add(weapon);
                            Text.Wait($"You pick up the {weapon.Name}.");
                        }

                        Loot.Remove(pickup);
                    }

                    else
                    {
                        Text.Wait("You leave the rest of the items in the room, they are of no use to you.");
                        break;
                    }
                }

                Text.Wait();
            }
        }
    }
}
