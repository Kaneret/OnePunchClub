using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class CommonPunch : ISkill
    {
        public string Name { get; }

        public string Description { get; }

        public CommonPunch()
        {
            Name = "Удар кулаком";
            Description = "Описание";
        }

        public void Setup(IFighter me)
        {
            me.attack += 4;
        }

        public void Teardown(IFighter me)
        {
            me.attack -= 4;
        }
    }
}
