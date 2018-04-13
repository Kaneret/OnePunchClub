using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class CommonBlock : ISkill
    {
        public string Name { get { return "Обычный блок"; } }

        public string Description
        {
            get
            {
                return "Описание";
            }
        }

        public bool Attack { get { return false; } }
        public bool Block { get { return true; } }
        public bool Evade { get { return false; } }

        public bool Activate { get; set; }

        public CommonBlock()
        {
            Activate = true;
        }

        public int Execute(MainHero hero)
        {
            hero.fightEnergy.DecreaseQuanity((int)10);
            //var rnd = new Random();
            //if (rnd.NextDouble() < hero.precision)
            //{
            return hero.power.value + hero.stamina.value + 5;
            //}
            //else
            //{
            //    return 0;
            //}
        }

        public int Execute(FightBot opponent)
        {
            opponent.energy.DecreaseQuanity((int)10);
            //var rnd = new Random();
            //if (rnd.NextDouble() < opponent.precision)
            //{
            return opponent.power.value + opponent.stamina.value + 5;
            //}
            //else
            //{
            //    return 0;
            //}
        }
    }
}
