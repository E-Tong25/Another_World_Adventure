using System;
namespace Another_World_Adventure
{
    public class Wine : BaseWine
    {
        public static List<Wine> wines = new List<Wine>();

        public Wine()
        {
            wines.Add(new Wine { ItemName = "Assyrtiko", ItemDescription = "Sokey, salty and cellar-worthy dry, white wine. Born from the volcanic-ash-rich soil.", ItemPrice = 10, ItemID = 8, ItemDrunkBoost = 20, WineType = WineTypes.DryWine });
            wines.Add(new Wine { ItemName = "Limnio", ItemDescription = "Sweet, red wine, a favorite among the great Odysseus.", ItemPrice = 10, ItemID = 9, ItemDrunkBoost = 20, WineType = WineTypes.SweetWine });
            wines.Add(new Wine { ItemName = "Liatiko", ItemDescription = "Delicately spicy, rick red-berry falvored with soft tannins and moderate acidity wine.", ItemPrice = 10, ItemID = 10, ItemDrunkBoost = 20, WineType = WineTypes.SourWine });

        }

    }
}

