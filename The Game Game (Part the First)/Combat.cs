using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    class Combat
    {
        public static List<Enemy> Enemies = new List<Enemy>();

        public enum DamageType
        {
            Melee,
            Range,
            Magic,
            Fire,
            Ice,
            Shock,
            Light
        }

        public static void Start()
        {
            Console.Clear();

            List<Combatant> Combatants = new List<Combatant>();
            List<Combatant> randomizeOrder = new List<Combatant>();
            randomizeOrder.AddRange(Game.Players);
            randomizeOrder.AddRange(Enemies);
            while (randomizeOrder.Count > 0)
            {
                int i = Technical.Random.Next(0, randomizeOrder.Count);
                Combatants.Add(randomizeOrder[i]);
                randomizeOrder.RemoveAt(i);
            }

            for (; ; )
            {
                foreach (Combatant thing in Combatants)
                {
                    if (thing is Player)
                    {
                        Player player = (Player)thing;
                        player.Turn();
                    }

                    else if (thing is Enemy)
                    {
                        Enemy foe = (Enemy)thing;
                        foe.Attack();
                    }

                    else
                    {
                        throw new Exception("combatant is neither of type Player nor Enemy.");
                    }

                    if (Game.Players.Count <= 0)
                    {
                        Console.WriteLine("You ded");
                    }

                    if (Enemies.Count <= 0)
                    {
                        Console.WriteLine("You emerged victorious in battle!");
                        return;
                    }
                }
            }
        }
    }
}
