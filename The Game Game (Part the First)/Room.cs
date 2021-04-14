using System;
using System.Collections.Generic;
using System.Linq;
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

                else if (thing is Area area)
                {
                    ExitAreas.Add(area);
                }

                else if (thing is string importantLookingString)
                {
                    if (EntryDescription == null)
                        EntryDescription = importantLookingString;
                    else
                    {
                        //Messages.Add(importantLookingString);
                        string[] split = importantLookingString.Split(">");
                        if (MessageID.TryGetValue(split[0], out int i))
                        {
                            Messages[i] = split[1];
                        }

                        else
                        {
                            Console.WriteLine("// DEBUG : code not in dictionary");
                        }
                    }
                }

                else if (thing is int roomID)
                {
                    NumberedExits.Add(roomID);
                }

                else
                {
                    Console.WriteLine($"// DEBUG : parameter not in correct type, in type {thing.GetType()}");
                }
            }
        }

        public string EntryDescription = null;
        public string[] Messages = new string[7];

        private Dictionary<string, int> MessageID = new Dictionary<string, int>
        {
            { "ENTER", 0 },
            { "ATK", 1 },
            { "LOOT", 2 },
            { "EMPTY", 3 },
            { "SEARCH", 4 },
            { "LEAVE", 5 },
            { "EXIT", 6 },
        };

        public List<Enemy> Encounters = new List<Enemy>();
        public List<Item> Items = new List<Item>();
        public List<Weapon> Weapons = new List<Weapon>();
        public List<Room> Exits = new List<Room>();
        public List<Area> ExitAreas = new List<Area>();
        public List<int> NumberedExits = new List<int>();

        public bool Enter()
        {
            CustomMessage(0);

            if (Encounters.Count > 0)
            {
                CustomMessage(1, "Upon entering the room, you see foes.");
                if (!Combat.Start(Encounters.ToArray()))
                    return false;
            }

            if (Items.Count > 0 || Weapons.Count > 0)
            {
                CustomMessage(2, "You see various items littered on the ground.");
                List<object> Loot = new List<object>();
                Loot.AddRange(Items);
                Loot.AddRange(Weapons);

                while (true)
                {
                    if (Loot.Count == 0)
                    {
                        CustomMessage(3, "There are no more items to pick up.");
                        break;
                    }

                    int? objectIndex = Text.Select(CustomMsgString(4, "You search the items for anything valuable."), true, Loot.ToArray());

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
                        CustomMessage(5, "You leave the rest of the items in the room, they are of no use to you.");
                        break;
                    }
                }
            }

            if (Exits.Any())
            {
                return Exits[Text.Select(CustomMsgString(6, "There is nothing more in this room of much interest. You look around to other entries to rooms."), Exits.ToArray())].Enter();
            }

            return true;
        }

        public bool Enter(out string exitMessage, out Area[] areas)
        {
            exitMessage = CustomMsgString(6, "There is nothing more in this room of much interest. You look around to other entries to rooms.");
            areas = ExitAreas.ToArray();
            return Enter();
        }

        private void CustomMessage(int index, string defaultMessage)
        {
            Text.Wait(Messages[index] ?? defaultMessage);
        }

        private void CustomMessage(int index)
        {
            if (Messages[index] != null)
                Text.Wait(Messages[index]);
        }

        private string CustomMsgString(int index, string defaultMessage)
        {
            return Messages[index] ?? defaultMessage;
        }
    }
}
