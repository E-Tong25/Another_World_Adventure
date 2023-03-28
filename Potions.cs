using System;
using static Another_World_Adventure.BaseWeapon;

namespace Another_World_Adventure
{
	public class Potion : BasePotion
    {
        public List<Potion> potions = new List<Potion>();

        public Potion()
        {
            potions.Add(new Potion { ItemName = "Ambrosia", ItemDescription = "Drink of the Gods. For your healing needs.", ItemPrice = 30, ItemID = 4, ItemHealthBoost = 20, PotionType = PotionTypes.Health });
            potions.Add(new Potion { ItemName = "Potion of Strength", ItemDescription = "Blood and sweat fill this vial. Boost your strength.", ItemPrice = 15, ItemID = 5, ItemStrengthBoost = 2, PotionType = PotionTypes.Strength });
            potions.Add(new Potion { ItemName = "Potion of Wisdom", ItemDescription = "Memories swirl in this viral. Boost your knowledge.", ItemPrice =15, ItemID = 6, ItemKnowledgeBoost = 2, PotionType = PotionTypes.Knowledge });
            potions.Add(new Potion { ItemName = "Aphrodite's Bath Water", ItemDescription = "The most lovely smell seeps through this vial. Boost your charm.", ItemPrice =15, ItemID = 7, ItemCharmBoost = 2, PotionType = PotionTypes.Charm });

        }

    }
}


