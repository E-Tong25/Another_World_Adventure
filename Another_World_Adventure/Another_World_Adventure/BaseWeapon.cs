using System;
namespace Another_World_Adventure
{
	public class BaseWeapon : BaseStatItem
	{
		public enum WeaponTypes
		{
			Sword, Bow, Spear
		}
		private WeaponTypes weaponType;

		public WeaponTypes WeaponType
		{
			get { return weaponType; }
			set { weaponType = value; }
		}
	}
}

