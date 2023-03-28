using System;
namespace Another_World_Adventure
{
    public class BaseStatItem : BaseItem
    {
        private int itemStrengthBoost;
        private int itemKnowledgeBoost;
        private int itemCharmBoost;
        private int itemHealthBoost;
        private int itemDrunkBoost;
        private int itemFoodBoost;

        public int ItemStrengthBoost
        {
            get { return itemStrengthBoost; }
            set { itemStrengthBoost = value; }
        }
        public int ItemKnowledgeBoost
        {
            get { return itemKnowledgeBoost; }
            set { itemKnowledgeBoost = value; }
        }
        public int ItemCharmBoost
        {
            get { return itemCharmBoost; }
            set { itemCharmBoost = value; }
        }
        public int ItemHealthBoost
        {
            get { return itemHealthBoost; }
            set { itemHealthBoost = value; }
        }
        public int ItemDrunkBoost
        {
            get { return itemDrunkBoost; }
            set { itemDrunkBoost = value; }
        }
        public int ItemFoodBoost
        {
            get { return itemFoodBoost; }
            set { itemFoodBoost = value; }
        }

    }
}

