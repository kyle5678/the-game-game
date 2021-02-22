using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    class Weapon
    {
        public Weapon(string name, AttackMove attack)
        {
            Name = name;
            AddAttack(attack);
        }

        public Weapon() { }

        public void AddAttack(AttackMove attack)
        {
            Attacks.Add(attack);
        }

        public string Name;
        public List<AttackMove> Attacks = new List<AttackMove>();
    }

    class StoneDagger : Weapon
    {
        public StoneDagger()
        {
            Name = "Stone Dagger";
            Attacks = new List<AttackMove>
            {
                new AttackMove("[a] swings their stone dagger.", Combat.DamageType.Melee, 2, 0.8f)
            };
        }
    }
}


