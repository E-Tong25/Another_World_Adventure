using System;
using System.Collections.Generic;

namespace Another_World_Adventure
{
    public static class Weapons
    {
        
        public static BaseWeapon HephaestusSword = new BaseWeapon("Hephaestus' Sword", "Light and duarble, you can tell it was made very well.", 6, BaseWeapon.WeaponTypes.Sword, 1);
        public static BaseWeapon ApollosBow = new BaseWeapon("Apollo's Bow", "Golden and blinding to the noraml eye, it was made for one with the Sun.", 6, BaseWeapon.WeaponTypes.Bow, 2);
        public static BaseWeapon SpearOfAthena = new BaseWeapon("Spear of Athena", "Engraved owl near the tip, infused with the spirit of wisdom and strategy paths the way to vicotry.", 6, BaseWeapon.WeaponTypes.Spear, 3);

    }
}