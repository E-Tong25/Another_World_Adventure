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
		public string? playerName;
		public int playerId;
		public int playerHealth = 100;
		public int playerStrength { get; set; }
		public int playerKnowledge { get; set; }
		public int playerCharm { get; set; }
		public int playerDamage = 0;
		public int playerPotion = 0;
		public int playerWeaponStrength = 0;
		public string? playerWeaponName { get; set; }
		public string? playerWeaponType { get; set; }
		public int playerCoins = 0;
		public int playerDrunkness = 0;
		public int playerHunger = 100;
		public string? playerGuildName { get; set; }

		public BaseCharacterGuildClass PlayerGuild { get; set; }

		public int CalculatedPlayerKnowledge
		{
			get { return playerKnowledge + PlayerGuild.GuildKnowledgeBoost; }
		}

        public int CalculatedPlayerStrength
        {
            get { return playerStrength + PlayerGuild.GuildStrengthBoost; }
        }

        public int CalculatedPlayerCharm
        {
            get { return playerCharm + PlayerGuild.GuildCharmBoost; }
        }

        public BaseWeapon PlayerWeapon { get; set; }

        public int CalculatedTotalPlayerAttackPower
		{
			get { return CalculatedPlayerStrength + PlayerWeapon.ItemStrengthBoost; }
		}





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