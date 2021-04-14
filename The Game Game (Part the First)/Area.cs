using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    class Area
    {
        public Area() { }

        public Area(params object[] elements)
        {
            Add(elements);
        }

        public void Add(params object[] elements)
        {
            NPCType npcsetting = NPCType.Static;
            foreach (object element in elements)
            {
                if (element is Enemy enemy)
                    Encounters.Add(enemy);
                else if (element is NPCType type)
                    npcsetting = type;

                else if (element is NPC npc)
                {
                    if (npcsetting == NPCType.Static)
                        StaticNPCs.Add(npc);
                    else if (npcsetting == NPCType.Wanderer)
                        WanderingNPCs.Add(npc);
                }

                else if (element is Area area)
                    Areas.Add(area);
                else if (element is Dungeon dungeon)
                    Dungeons.Add(dungeon);
                else if (element is string boop)
                    Name = boop;

                else
                    Console.WriteLine($"// DEBUG : parameter not in correct type, in type {element.GetType()}");
            }
        }

        public string Name;

        public List<Enemy> Encounters = new List<Enemy>();
        public double EncounterChanceDay;
        public double EncounterChanceNight;

        public List<object> StaticNPCs = new List<object>();
        public List<object> WanderingNPCs = new List<object>();

        public List<Area> Areas = new List<Area>();
        public List<bool> AreasFound = new List<bool>();

        public List<Dungeon> Dungeons = new List<Dungeon>();
        public List<bool> DungeonsFound = new List<bool>();

        public bool Enter()
        {
            int choice = Text.Select("What do you want to do?", "Wander", "Travel", "Camp");
            if (choice == 0)
                return Wander();
            else if (choice == 1)
                return Travel();
            else if (choice == 2)
                return Camp();
            else
                return false;   // this will never happen (put here to stop error)
        }

        public bool Wander()
        {
            if (0.2.Chance())
            {
                Area area = Areas.GetRandom(out int index);
                if (AreasFound[index])
                {
                    Text.Wait($"You find you're looking at {area.Name}");
                }

                else
                {
                    AreasFound[index] = true;
                    Text.Wait($"You found {area.Name}");
                }
            }

            if (0.1.Chance())
            {
                Dungeon dungeon = Dungeons.GetRandom(out int index);
                if (DungeonsFound[index])
                {
                    Text.Wait($"You find you're looking at {dungeon.Name}");
                }

                else
                {
                    DungeonsFound[index] = true;
                    Text.Wait($"You found {dungeon.Name}");
                }
            }

            return Enter();
        }

        public bool Travel()
        {
            return false;
        }

        public bool Camp()
        {
            return false;
        }
    }
}
