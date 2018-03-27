using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    class CommonPunch : ISkill
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

        /// <summary>
        /// для использования персонажем
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="opponent"></param>
        public void Execute(MainHero hero, FightBot opponent)
        {

        }

        /// <summary>
        /// для использования ботом
        /// </summary>
        /// <param name="opponent"></param>
        /// <param name="hero"></param>
        public void Execute(FightBot opponent, MainHero hero)
        {

        }
    }
}
