using System;
using System.Collections.Generic;
using System.Text;

namespace The_Game_Game__Part_the_First_
{
    public enum StoryArc
    {
        Chapter1,
    }

    class Story
    {
        public static Dictionary<StoryArc, Func<StoryArc?>> StoryDictionary = new Dictionary<StoryArc, Func<StoryArc?>>
        {
            { StoryArc.Chapter1, ThroughTheDarkness },
        };
        
        public static void Storytell(StoryArc? part)
        {
            if (!part.HasValue)
            {
                Console.Clear();
                Text.Center(1);
                Text.Center("You have failed.");
                return;
            }

            else if (StoryDictionary.TryGetValue(part.Value, out var storyFunction))
            {
                Storytell(storyFunction());
            }
        }

        class Choice
        {
            public static int EscapeSpiderweb;
        }

        public static StoryArc? ThroughTheDarkness()
        {
            Console.Clear();
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

            Game.PlayerOne.Weapons.Add(new StoneDagger());
            //Game.Players[0].Weapons.Add(new StoneDagger());

            Text.Wait("Quickly, before the spider comes back, you swing blindly through the darkness.");
            Text.Wait("The dagger makes its mark. The spiderling reels backward, hissing in pain.");
            Text.Wait("And so, the struggle begins...");

            Combat.Start(true, true, new NimbleSpiderling());

            Text.Wait("The spider, letting out a shriek of pain, scrambles away quickly, leaving you with time to rest and think.");
            Text.Wait("Nothing comes into your mind. You grope around in the darkness.");
            Text.Wait("You soon find that you have... a backpack?");
            Text.Wait("Reaching within, your hands close on a handle.");
            Text.Wait("*click*");
            Text.Wait("Suddenly, a blinding light materialises.");
            Text.Wait("You are holding a small black flashlight, and shining it around the cave, you see nothing but thick spiderweb in every direction.");
            
            Choice.EscapeSpiderweb = Text.Choose("But you need to get out, somehow...", "Cut your way out with your dagger.", "Walk through the webs.", "Stay");
            if (Choice.EscapeSpiderweb == 1)
            {
                Text.Wait("You cut through the webs with your dagger.");
                Text.Wait("More spiders come to you, hissing, angry now that you've damaged their nest.");
                Text.Wait("You soon discover that the spiders are unfamiliar with light, so you shine your flashlight at every spider coming close");
                Text.Wait("Through a cut path, you find yourself in a domed cavern.");
            }

            else if (Choice.EscapeSpiderweb == 2)
            {
                Text.Wait("The thick spiderweb clings to your clothing as you struggle through.");
                Text.Wait("You finally succumb to the webs, collapsing, entangled, cocooned within the white silk.");
                Text.Wait("You manage to escape, cutting through with your dagger...");
                Text.Wait("...only to find yourself surrounded by spiders, hoping for a hearty feast.");
                Text.Wait("Your flashlight flickers, and fades. Through darkness, the spiders bite.");

                if (!Combat.Start(3, new Spiderling()))
                    return null;

                Text.Wait("How did you survive.");
            }

            else if (Choice.EscapeSpiderweb == 3)
            {
                Text.Wait("Your flashlight goes out. Left in darkness, you shiver.");
                Text.Wait("Through the dark, teeth sink into you.");
                Text.Wait("You scream no more.");
                return null;
            }

            return StoryArc.Chapter1;
        }
    }
}