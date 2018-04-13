using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class CommonPunch : ISkill
    {
        public string Name { get { return "Удар кулаком"; } }

        public string Description
        {
            get
            {
                return "Описание";
            }
        }

        public bool Attack { get { return true; } }
        public bool Block { get { return false; } }
        public bool Evade { get { return false; } }

        public bool Activate { get; set; }

        public CommonPunch()
        {
            Activate = true;
        }

        public int Execute(MainHero hero)
        {
            hero.fightEnergy.DecreaseQuanity((int)10);
            //var rnd = new Random();
            //if (rnd.NextDouble() < hero.precision)
            //{
            return (hero.power.value * 2) + 10;
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
            return (opponent.power.value * 2) + 10;
            //}
            //else
            //{
            //    return 0;
            //}
        }
    }
}
