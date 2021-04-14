using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    [Serializable]
    class Enemy : Combatant
    {
        public Enemy() { }

        public Enemy(string name, int health, params AttackMove[] attack)
        {
            Name = name;
            MaxHealth = health;
            CurrentHealth = MaxHealth;
            Attacks.AddRange(attack);
        }

        public Enemy(string name, int health, float threat, params AttackMove[] attack)
        {
            Name = name;
            MaxHealth = health;
            CurrentHealth = MaxHealth;
            ThreatRate = threat;
            Attacks.AddRange(attack);
        }

        public string Name;
        public int CurrentHealth;
        public int MaxHealth;
        public List<AttackMove> Attacks = new List<AttackMove>();
        public float DodgeRate = 0.0f;
        public float ThreatRate;

        public void Attack()
        {
            AttackMove attack = Attacks[Technical.Random.Next(0, Attacks.Count)];
            attack.Attack(Game.PlayerOne, Name);
            //attack.Attack(Game.Players[0], Name);
        }

        public void Damage(int damage, Combat.DamageType type)
        {
            if ((float)Technical.Random.NextDouble() < DodgeRate)
            {
                Text.Wait($"But {Name} dodged!");
            }

            else
            {
                TakeDamage(damage, type);
            }
        }

        public void TakeDamage(int damage, Combat.DamageType type)
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

    [Serializable]
    class NimbleSpiderling : Enemy
    {
        public NimbleSpiderling()
        {
            Name = "Spiderling";
            MaxHealth = 1;
            CurrentHealth = 1;
            Attacks = new List<AttackMove> { new AttackMove("[a] bites into your skin.", Combat.DamageType.Melee, 1, 0.5f) };
            DodgeRate = 0.75f;
        }
    }

    [Serializable]
    class Spiderling : Enemy
    {
        public Spiderling()
        {
            Name = "Spiderling";
            MaxHealth = 3;
            CurrentHealth = 3;
            Attacks = new List<AttackMove> { new AttackMove("[a] sinks its fangs into you.", Combat.DamageType.Melee, 1, 0.5f) };
            DodgeRate = 0.05f;
        }
    }
}
