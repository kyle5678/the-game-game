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

        public void Add(params Room[] rooms)
        {
            DungeonRooms.AddRange(rooms);
        }

        public List<Room> DungeonRooms = new List<Room>();

        public bool Enter(int entryRoom = 0)
        {
            while (true)
            {
                Room currentRoom = DungeonRooms[entryRoom];
                if (!currentRoom.Enter())
                    return false;


                List<Room> enterableRooms = new List<Room>();
                foreach (int id in currentRoom.NumberedExits)
                {
                    enterableRooms.Add(DungeonRooms[id]);
                }

                Text.Select("Room Select.", enterableRooms.ToArray());
            }
        }
    }
}
