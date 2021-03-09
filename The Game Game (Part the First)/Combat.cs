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

        public static bool Start(bool clearAfter, bool storyImportant, params Enemy[] enemies)
        {
            Enemies.AddRange(enemies);
            return Start(clearAfter, storyImportant);
        }

        public static bool Start(bool clearAfter, params Enemy[] enemies)
        {
            return Start(clearAfter, false, enemies);
        }

        public static bool Start(params Enemy[] enemies)
        {
            return Start(true, enemies);
        }

        public static bool Start(bool clearAfter, params object[] enemiesOrQuantity)
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
                        Enemy newEnemy = Technical.DeepClone((Enemy)enemyOrInt);
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

            return Start(clearAfter);
        }

        public static bool Start(params object[] enemiesOrQuantity)
        {
            return Start(true, enemiesOrQuantity);
        }

        public static bool Start(bool clearAfter = true, bool storyImportant = false)
        {
            Console.Clear();

            List<Combatant> CombatOrder = new List<Combatant>();
            List<Combatant> randomizeOrder = new List<Combatant> { Game.PlayerOne };
            //randomizeOrder.AddRange(Game.Players);
            randomizeOrder.AddRange(Enemies);
            while (randomizeOrder.Count > 0)
            {
                int i = Technical.Random.Next(0, randomizeOrder.Count);
                CombatOrder.Add(randomizeOrder[i]);
                randomizeOrder.RemoveAt(i);
            }

            for (; ; )
            {
                for (int i = 0; i < CombatOrder.Count; i++)
                {
                    Combatant thing = CombatOrder[i];
                    if (thing is Player)
                    {
                        Player player = (Player)thing;
                        Enemy victim = player.Turn();

                        if (victim != null)
                        {
                            if (victim.CurrentHealth <= 0)
                            {
                                CombatOrder.Remove(victim);
                            }
                        }
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

                    if (Game.PlayerOne.Dead)
                    {
                        Text.Wait("You fall, mortally wounded.");
                        if (storyImportant)
                        {
                            Text.Wait("But a force, a powerful, yet somehow familiar one, refuses to let you die here.");
                        }

                        else
                        {
                            return false;
                        }
                    }

                    if (Enemies.Count <= 0)
                    {
                        Text.Wait("You emerged victorious in battle!");
                        if (clearAfter)
                            Console.Clear();
                        return true;
                    }
                }
            }
        }
    }
}
