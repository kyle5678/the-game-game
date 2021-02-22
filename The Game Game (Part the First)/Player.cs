﻿using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    class Player : Combatant
    {
        public Player(string name, int health)
        {
            Name = name;
            MaxHealth = health;
            CurrentHealth = MaxHealth;

            if (Game.SecretDeveloperMode)
            {
                Weapons.Add(new Weapon("Light", new AttackMove("[a] radiates intense light.", Combat.DamageType.Light, 2147483647)));
            }
        }

        public string Name;
        public int CurrentHealth;
        public int MaxHealth;
        public List<Weapon> Weapons = new List<Weapon>();

        public void Turn()
        {
            Console.WriteLine($"{Name}, it's your turn!");
            Console.WriteLine("\t1. Attack");
            Console.WriteLine("\t2. Use Item");
            Console.WriteLine("\t3. Skip Turn");
            Console.WriteLine("\t4. Flee");

            while (true)
            {
                ConsoleKeyInfo keypress = Console.ReadKey(true);
                if (keypress.Key == ConsoleKey.D1)
                {
                    Weapon weapon;
                    Enemy victim;
                    AttackMove attack;

                    Console.WriteLine("Which weapon would you like to attack with?");
                    foreach (Weapon aruu in Weapons)
                    {
                        Console.WriteLine($"\t{Weapons.IndexOf(aruu) + 1}. {aruu.Name}");
                    }

                    while (true)
                    {
                        keypress = Console.ReadKey(true);
                        if (int.TryParse(keypress.KeyChar.ToString(), out int weaponIndex))
                        {
                            if (weaponIndex <= Weapons.Count)
                            {
                                weapon = Weapons[weaponIndex - 1];
                                break;
                            }
                        }
                    }

                    Console.WriteLine($"Attack which enemy with {weapon.Name}?");
                    foreach (Enemy aruu in Combat.Enemies)
                    {
                        Console.WriteLine($"\t{Combat.Enemies.IndexOf(aruu) + 1}. {aruu.Name}");
                    }

                    while (true)
                    {
                        keypress = Console.ReadKey(true);
                        if (int.TryParse(keypress.KeyChar.ToString(), out int enemyIndex))
                        {
                            if (enemyIndex <= Combat.Enemies.Count)
                            {
                                victim = Combat.Enemies[enemyIndex - 1];
                                break;
                            }
                        }
                    }

                    Console.WriteLine($"Use which attack of {weapon.Name}?");
                    foreach (AttackMove aruu in weapon.Attacks)
                    {
                        Console.WriteLine($"\t{weapon.Attacks.IndexOf(aruu) + 1}. {aruu.Type}");
                    }

                    while (true)
                    {
                        keypress = Console.ReadKey(true);
                        if (int.TryParse(keypress.KeyChar.ToString(), out int attackIndex))
                        {
                            if (attackIndex <= weapon.Attacks.Count)
                            {
                                attack = weapon.Attacks[attackIndex - 1];
                                break;
                            }
                        }
                    }

                    attack.Attack(victim, Name);

                    break;
                }

                if (keypress.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("Functionality not available yet.");
                }

                if (keypress.Key == ConsoleKey.D3)
                {
                    Text.Wait("You waited...");
                    break;
                }

                if (keypress.Key == ConsoleKey.D4)
                {
                    Console.WriteLine("Functionality not available yet.");
                }
            }
        }

        public void Damage(int damage, Combat.DamageType type)
        {
            CurrentHealth -= damage;
            Text.Wait($"{Name} took {damage} damage, leaving them with {CurrentHealth}!");
            if (CurrentHealth <= 0)
            {
                Text.Wait($"{Name} dies from the attack!");
                Game.Players.Remove(this);
            }
        }
    }
}