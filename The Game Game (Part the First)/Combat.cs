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
            Poison,
            Light
        }

        public static void Start(bool clearAfter, params Enemy[] enemies)
        {
            Enemies.AddRange(enemies);
            Start(clearAfter);
        }

        public static void Start(params Enemy[] enemies)
        {
            Start(true, enemies);
        }

        public static void Start(bool clearAfter, params object[] enemiesOrQuantity)
        {
            int quantity = 1;
            foreach (object enemyOrInt in enemiesOrQuantity)
            {
                if (enemyOrInt is int)
                {
                    quantity = (int)enemyOrInt;
                }

                else if (enemyOrInt is Enemy)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        Enemy newEnemy = (Enemy)enemyOrInt;
                        newEnemy.Name += $" #{i + 1}";
                        Enemies.Add(newEnemy);
                    }

                    quantity = 1;
                }

                else
                {
                    // ignore value
                    Console.WriteLine("// DEBUG : parameter must be in type Enemy or int");
                }
            }

            Start(clearAfter);
        }

        public static void Start(params object[] enemiesOrQuantity)
        {
            Start(true, enemiesOrQuantity);
        }

        public static void Start(bool clearAfter = true)
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

                    Text.Line();

                    if (Game.Players.Count <= 0)
                    {
                        Console.WriteLine("You ded");
                    }

                    if (Enemies.Count <= 0)
                    {
                        Text.Wait("You emerged victorious in battle!");
                        if (clearAfter)
                            Console.Clear();
                        return;
                    }
                }
            }
        }
    }
}
