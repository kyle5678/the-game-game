using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    class AttackMove
    {
        public AttackMove(string message, Combat.DamageType damageType, int minDamage, int maxDamage, float? accuracy)
        {
            Message = message;
            Type = damageType;
            MinimumDamage = minDamage;
            MaximumDamage = maxDamage;
            Accuracy = accuracy;
        }

        public AttackMove(string message, Combat.DamageType damageType, int minDamage, int maxDamage)
        {
            Message = message;
            Type = damageType;
            MinimumDamage = minDamage;
            MaximumDamage = maxDamage;
        }

        public AttackMove(string message, Combat.DamageType damageType, int fixedDamage, float? accuracy)
        {
            Message = message;
            Type = damageType;
            MinimumDamage = fixedDamage;
            MaximumDamage = fixedDamage;
            Accuracy = accuracy;
        }

        public AttackMove(string message, Combat.DamageType damageType, int fixedDamage)
        {
            Message = message;
            Type = damageType;
            MinimumDamage = fixedDamage;
            MaximumDamage = fixedDamage;
        }

        public Combat.DamageType Type;
        private int MinimumDamage;
        private int MaximumDamage;
        private float? Accuracy = 1.0f;
        public string Message;

        public void Attack(Player target, string attacker)
        {
            Text.Wait(Message.Replace("[a]", attacker));

            if ((float)Technical.Random.NextDouble() < Accuracy)
            {
                target.Damage(Technical.Random.Next(MinimumDamage, MaximumDamage + 1), Type);
            }

            else
            {
                Text.Wait("But it missed!");
            }
        }

        public void Attack(Enemy target, string attacker)
        {
            Text.Wait(Message.Replace("[a]", attacker));

            if (Accuracy == null)
            {
                target.TakeDamage(Technical.Random.Next(MinimumDamage, MaximumDamage + 1), Type);
            }

            else if ((float)Technical.Random.NextDouble() < Accuracy)
            {
                target.Damage(Technical.Random.Next(MinimumDamage, MaximumDamage + 1), Type);
            }

            else
            {
                Text.Wait("But it missed!");
            }
        }
    }
}
