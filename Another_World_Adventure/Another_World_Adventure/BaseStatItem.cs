using System;
namespace Another_World_Adventure
{
    public class BaseStatItem : BaseItem
    {
        private int strength;
        private int knowledge;
        private int charm;
        private int health;

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        public int Knowledge
        {
            get { return knowledge; }
            set { knowledge = value; }
        }
        public int Charm
        {
            get { return charm; }
            set { charm = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
    }
}

