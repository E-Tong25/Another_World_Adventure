using System;
namespace Another_World_Adventure
{
    public static class Wines
    {

        public static BaseWine Assyrtiko = new BaseWine("Assyrtiko", "Smokey, salty and cellar-worthy dry, white wine. Born from the volcanic-ash-rich soil.", 10, 20 , BaseWine.WineTypes.DryWine, 8);
        public static BaseWine Limnio = new BaseWine("Limnio", "Sweet, red wine, a favorite among the great Odysseus.", 10, 20, BaseWine.WineTypes.SweetWine, 9);
        public static BaseWine Liatiko = new BaseWine("Liatiko", "Delicately spicy, rich red-berry falvored with soft tannins and moderate acidity wine.", 10, 20, BaseWine.WineTypes.SourWine, 3);

    }
}

