using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public interface ISkill
    {
        string Name { get; }
        string Description { get; }
        bool Attack { get; }
        bool Block { get; }
        bool Evade { get; }//уворот
        void Execute(MainHero hero, FightBot opponent);
        void Execute(FightBot opponent, MainHero hero);
    }
}
