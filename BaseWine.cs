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
    }
}

