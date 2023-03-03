using System;
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
    }
}

