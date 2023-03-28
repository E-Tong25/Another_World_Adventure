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
    }
}

