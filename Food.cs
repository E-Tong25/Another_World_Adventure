using System;
namespace Another_World_Adventure
{
    public class Food : BaseFood
    {
        public List<Food> foods = new List<Food>();

        public Food()
        {
            foods.Add(new Food { ItemName = "Honey Vinegar Cabbage", ItemDescription = "Sliced, washed, and drained, sprinkled with honey vinegar and a little bit of silphium. Sworn by all around for its cure of hangovers", ItemPrice =5, ItemID = 11, ItemFoodBoost = 20, FoodType = FoodTypes.Savories });
            foods.Add(new Food { ItemName = "Bowl of Fruit", ItemDescription = "Freshly picked fruits, from a nearby orchard.", ItemPrice = 5, ItemID = 12, ItemFoodBoost = 20, FoodType = FoodTypes.Sweets });
            foods.Add(new Food { ItemName = "Roasted Lamb", ItemDescription = "Marianated overnight, turned occasionally for full flavor absorption, cooked, and sliced into thick pieces, covered a date, wine sauce.", ItemPrice = 10, ItemID = 13, ItemFoodBoost = 50, FoodType = FoodTypes.Savories });
            foods.Add(new Food { ItemName = "Hipponax's Pancakes", ItemDescription = "Thicker than crepes, are pan-fried on a smokeless fire and served with honesy and toasted sesame seeds.", ItemPrice = 10, ItemID = 14, ItemFoodBoost = 50, FoodType = FoodTypes.Sweets });

        }

    }
}

