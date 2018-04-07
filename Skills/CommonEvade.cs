using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    class CommonEvade : ISkill
    {
        public string Name { get { return "Обычный уворот"; } }

        public string Description
        {
            get
            {
                return "Описание";
            }
        }

        public bool Attack { get { return false; } }
        public bool Block { get { return false; } }
        public bool Evade { get { return true; } }

        public bool Activate { get; set; }

        public CommonEvade()
        {
            Activate = true;
        }

        public int Execute(MainHero hero)
        {
            hero.fightEnergy.DecreaseQuanity((int)10);
            var rnd = new Random();
            if (rnd.NextDouble() < (hero.dexterity.value/10))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Execute(FightBot opponent)
        {
            opponent.energy.DecreaseQuanity((int)10);
            var rnd = new Random();
            if (rnd.NextDouble() < (opponent.dexterity.value / 10))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
