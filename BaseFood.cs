using System;

namespace Another_World_Adventure
{
    public class BaseFood : BaseStatItem
    {
        public enum FoodTypes
        {
            Sweets, Savories
        }
        private FoodTypes foodType;

        public FoodTypes FoodType
        {
            get { return foodType; }
            set { foodType = value; }
        }

        public BaseFood(string foodName, string foodDescription, int foodPrice, int foodBoost, FoodTypes typeOfFood, int foodID)
        {
            ItemName = foodName;
            ItemDescription = foodDescription;
            ItemPrice = foodPrice;
            ItemFoodBoost = foodBoost;
            FoodType = typeOfFood;
            ItemID = foodID;
        }
    }
}

