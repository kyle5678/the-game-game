using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    class Enemy : Combatant
    {
        public Enemy(string name, int health, AttackMove attack)
        {
            Name = name;
            MaxHealth = health;
            CurrentHealth = MaxHealth;
            Attacks.Add(attack);
        }

        public Enemy() { }

        public string Name;
        public int CurrentHealth;
        public int MaxHealth;
        public List<AttackMove> Attacks = new List<AttackMove>();
        public float DodgeRate = 0.0f;

        public void Attack()
        {
            AttackMove attack = Attacks[Technical.Random.Next(0, Attacks.Count)];
            attack.Attack(Game.Players[0], Name);
        }

        public void Damage(int damage, Combat.DamageType type)
        {
            if ((float)Technical.Random.NextDouble() < DodgeRate)
            {
                Text.Wait($"But {Name} dodged!");
            }

            else
            {
                CurrentHealth -= damage;
                Text.Wait($"{Name} took {damage} damage from the attack.");
                if (CurrentHealth <= 0)
                {
                    Text.Wait($"{Name} dies from the attack!");
                    Combat.Enemies.Remove(this);
                }
            }
        }
    }

    class Spiderling : Enemy
    {
        public Spiderling()
        {
            Name = "Spiderling";
            MaxHealth = 1;
            CurrentHealth = 1;
            Attacks = new List<AttackMove> { new AttackMove("[a] bites into your skin.", Combat.DamageType.Melee, 1, 0.5f) };
            DodgeRate = 0.9f;
        }
    }
}
