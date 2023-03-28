using System;
using System.Collections.Generic;

namespace Another_World_Adventure
{
	public class BaseItem
	{
		private string? itemName;
		private string? itemDescription;
		private int itemID;
		private int itemPrice;
		public enum ItemTypes { Potion, Weapon, Food, Wine }

		private ItemTypes itemType;

		public string ItemName
		{
			get { return itemName; }
			set { itemName = value; }
		}
		public string ItemDescription
		{
			get { return itemDescription; }
			set { itemDescription = value; }
		}
		public int ItemID
		{
			get { return itemID; }
			set { itemID = value; }
		}
        public int ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }
        public ItemTypes ItemType
		{
			get { return itemType; }
			set { itemType = value; }
		}

		


    
    }
}


