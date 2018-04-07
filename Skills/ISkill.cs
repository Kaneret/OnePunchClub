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
        bool Activate { get; set; }
        int Execute(MainHero hero);
        int Execute(FightBot opponent);
    }
}
