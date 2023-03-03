using System;
namespace Another_World_Adventure
{
    public class Weapon : BaseWeapon
    {
        public List<Weapon> weapons = new List<Weapon>();

        weapons.Add(new Weapon{ string ItemName = "Hephaestus Sword", ItemDescription = "Light and duarble, you can tell it was made very well.", ItemID = 1, Strength = 6, WeaponType = Sword});
        weapons.Add(new Weapon{ string ItemName = "Apollo's Bow", ItemDescription = "Golden and blinding to the noraml eye, it was made for one with the Sun.", ItemID = 2, Strength = 6, WeaponType = Bow});
        weapons.Add(new Weapon { string ItemName = "Spear of Athena", ItemDescription = "Engraved owl near the tip, infused with the spirit of wisdom and strategy paths the way to vicotry.", ItemID = 3, Strength = 6, WeaponType = Spear }); 

    }
}