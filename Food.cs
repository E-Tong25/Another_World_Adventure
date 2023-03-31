using System;

namespace Another_World_Adventure
{
    public static class Food
    {

        public static BaseFood HoneyVinegarCabbage = new BaseFood("Honey Vinegar Cabbage", "Sliced, washed, and drained, sprinkled with honey vinegar and a little bit of silphium. Sworn by all around for its cure of hangovers.", 5, 20, BaseFood.FoodTypes.Savories, 11);
        public static BaseFood BowlOfFruit = new BaseFood("Bowl of Fruit", "Freshly picked fruits, from a nearby orchard.", 5, 20, BaseFood.FoodTypes.Sweets, 12);
        public static BaseFood RoastedLamb = new BaseFood("Roasted Lamb", "Marianated overnight, turned occasionally for full flavor absorption, cooked, and sliced into thick pieces, covered a date, wine sauce.", 10, 50, BaseFood.FoodTypes.Savories, 13);
        public static BaseFood HipponaxsPanckaes = new BaseFood("Hipponax's Pancakes", "Thicker than crepes, are pan-fried on a smokeless fire and served with honesy and toasted sesame seeds.", 10, 50, BaseFood.FoodTypes.Sweets, 14);

    }
}

