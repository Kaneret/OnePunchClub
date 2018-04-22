using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public interface IFighter
    {
        int block { get; set; }
        int evasion { get; set; }
        int attack { get; set; }

        ISkill GetSkill();
        void Damage(int damage);
    }
}
