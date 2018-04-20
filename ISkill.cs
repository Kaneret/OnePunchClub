using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public interface ISkill
    {
        void Setup(IFighter me);
        void Teardown(IFighter me);
    }
}
