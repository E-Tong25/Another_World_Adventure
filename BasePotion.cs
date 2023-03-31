using System;
using static Another_World_Adventure.BaseWeapon;

namespace Another_World_Adventure
{
    public class BasePotion : BaseStatItem
    {
        public enum PotionTypes
        {
            Health, Strength, Knowledge, Charm
        }
        private PotionTypes potionType;

        public PotionTypes PotionType
        {
            get { return potionType; }
            set { potionType = value; }
        }

        public BasePotion(string potionName, string potionDescription,int potionPrice, int potionHealthBoost, int potionStrengthBoost, int potionKnowledgeBoost, int potionCharmBoost, PotionTypes typeOfPotion, int potionID)
        {
            ItemName = potionName;
            ItemDescription = potionDescription;
            ItemPrice = potionPrice;
            ItemHealthBoost = potionHealthBoost;
            ItemStrengthBoost = potionStrengthBoost;
            ItemKnowledgeBoost = potionKnowledgeBoost;
            ItemCharmBoost = potionCharmBoost;
            PotionType = typeOfPotion;
            ItemID = potionID;
        }
    }
}

