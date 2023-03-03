using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Another_World_Adventure
{
	[Serializable]
	public class Player
	{
		public string name;
		public int id;
		public int health = 100;
		public int strength { get; set; }
		public int knowledge { get; set; }
		public int charm { get; set; }
		public int damage = 0;
		public int potion = 0;
		public int weaponStrength = 0;
		public string weaponName;
		public string weaponType;
		public int coins = 0;
		public int soberness = 100;
		public int hunger = 0;
		public string guildName { get; set; }

	

		//May not need below
		public int mods = 0;

		public int GetStat()
		{
			int upper = (2 * mods + 5);
			int lower = (mods + 2);
			return Program.rand.Next(lower,upper);
		}

		// may not need this
        public int GetHealth()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return Program.rand.Next(lower, upper);
        }
        public int GetPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return Program.rand.Next(lower, upper);
        }
		public int GetCoins()
		{
			int upper = (10 * mods + 50);
			int lower = (10* mods + 10);
			return Program.rand.Next(lower,upper);
		}

    }
}