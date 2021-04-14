using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    class Dungeon
    {
        public Dungeon()
        {

        }

        public Dungeon(params Room[] rooms)
        {
            Add(rooms);
        }

        public Dungeon(string name, params Room[] rooms)
        {
            Name = name;
            Add(rooms);
        }

        public void Add(params Room[] rooms)
        {
            DungeonRooms.AddRange(rooms);
        }

        public string Name;
        public List<Room> DungeonRooms = new List<Room>();

        public bool Enter(int entryRoom = 0)
        {
            Room currentRoom = DungeonRooms[entryRoom];
            while (true)
            {
                if (!currentRoom.Enter(out string roomSelectMessage, out Area[] areas))
                    return false;


                List<Room> enterableRooms = new List<Room>();
                foreach (int id in currentRoom.NumberedExits)
                {
                    enterableRooms.Add(DungeonRooms[id]);
                }

                List<object> available = new List<object>();
                available.AddRange(areas);
                available.AddRange(enterableRooms);

                object selected = available[Text.Select(roomSelectMessage, available.ToArray())];
                if (selected is Room room)
                {
                    currentRoom = room;
                }

                else if (selected is Area area)
                {
                    return area.Enter();
                }

                else
                {
                    Console.WriteLine($"// DEBUG : selected object not in correct type, in type {selected.GetType()}");
                }
            }
        }
    }
}
