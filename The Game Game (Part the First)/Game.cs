using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    class Game
    {
        public static Player PlayerOne;
        //public static List<Player> Players = new List<Player>();

        public static bool SecretDeveloperMode = false;
        public static void ActivateSecretDeveloperMode()
        {
            SecretDeveloperMode = true;
        }

        public static Dungeon SpiderHollow = new Dungeon
        (
            "Spider Hollow",
            new Room(
                "A crude doorway. A faint glow eminates from within.",
                "ENTER>Looking around, spiderwebs cover the room.",
                "ATK>From above, a spider drops, ready to bite.",
                new Spiderling(),
                new Item("Unpleasant Meat", ItemUse.Heal, 2),
                1
            ),

            new Room(
                "A tiny hole in the wall that you can barely squeeze through.",
                "ENTER>OREAORAOROAROAROAROROARO"
            )
        );

        public static Area HollowForest = new Area
        (
            
        );
    }
}
