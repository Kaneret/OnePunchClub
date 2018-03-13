using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    class MainHero : IHero
    {
        public Endurance endurance { get; }
        public Health health { get; }
        public Mood mood { get; }
        public Satiety satiety { get; }

        public ActiveSlots ativeSlots { get; }
        public Armor armor { get; }
        public Energy energy { get; }
        public EnergyRegen eReg { get; }
        public Hitpoints hp { get; }
        public Precision precision { get; }

        public Dexterity dexterity { get; }
        public Power power { get; }
        public Stamina stamina { get; }
    }
}
