using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    class Story
    {
        public static void Chapter1()
        {
            Text.Center(2);
            Text.Center("Chapter 1");
            Text.Wait();
            Text.Center("Through the Darkness");
            Text.Wait();

            Console.Clear();
            Text.Wait("You gain consciousness.");
            Text.Wait("Through clouded eyes, your gaze wanders through the space you lie within.");
            Text.Wait("The little information coming into your eyes is just enough to make you guess that this may be a spider nest.");
            Text.Wait("Just as you struggle to sit up, a small spider descends from above, held by woven string.");
            Text.Wait("Swinging forward, the nimble spiderling bites deep into your skin.");
            Text.Wait("Through gritted teeth, you scramble around for anything to defend yourself with.");
            Text.Wait("The handle of a crude stone dagger comes into your hand.");

            Game.Players[0].Weapons.Add(new StoneDagger());

            Text.Wait("Quickly, before the spider comes back, you swing blindly through the darkness.");
            Text.Wait("The dagger makes its mark. The spiderling reels backward, hissing in pain.");
            Text.Wait("And so, the struggle begins...");

            Combat.Enemies.Add(new Spiderling());
            Combat.Start();
        }
    }
}
