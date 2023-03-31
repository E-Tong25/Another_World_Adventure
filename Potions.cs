using System;

namespace Another_World_Adventure
{
	public class Potions
    {
        public static BasePotion Ambrosia = new BasePotion("Ambrosia", "Drink of the Gods. For your healing needs.", 30, 20, 0, 0, 0, BasePotion.PotionTypes.Health, 4);
        public static BasePotion PotionOfStrength = new BasePotion("Potion of Strength", "Blood and sweat fill this vial. Boost your strength.", 15, 0, 2, 0, 0, BasePotion.PotionTypes.Strength, 5);
        public static BasePotion PotionOfWisdom = new BasePotion("Potion of Wisdom", "Memories swirl in this viral. Boost your knowledge.", 15, 0, 0, 2, 0, BasePotion.PotionTypes.Knowledge, 6 );
        public static BasePotion AphroditesBathWater = new BasePotion("Aphrodite's Bath Water", "The most lovely smell seeps through this vial. Boost your charm.", 15, 0, 0, 0, 2, BasePotion.PotionTypes.Charm, 7);
    }

}


