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

    class Light : Weapon
    {
        public Light()
        {
            Name = "Light";
            Attacks = new List<AttackMove>
            {
                new AttackMove("A blinding flash of light eminates from [a]'s outstretched hands.", Combat.DamageType.Light, 0, int.MaxValue - 1, null)
            };
        }
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


