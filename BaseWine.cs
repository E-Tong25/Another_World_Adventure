using System;

namespace Another_World_Adventure
{
    public class BaseWine : BaseStatItem
    {
        public enum WineTypes
        {
            SweetWine, DryWine, SourWine
        }
        private WineTypes wineType;

        public WineTypes WineType
        {
            get { return wineType; }
            set { wineType = value; }
        }

        public BaseWine(string wineName, string wineDescription, int winePrice, int wineDrunkBoost, WineTypes typeOfWine, int wineID)
        {
            ItemName = wineName;
            ItemDescription = wineDescription;
            ItemPrice = winePrice;
            ItemDrunkBoost = wineDrunkBoost;
            WineType = typeOfWine;
            ItemID = wineID;
        }
    }
}

