using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class CommonEvasion : ISkill
    {
        public string Name { get; }

        public string Description { get; }

        public CommonEvasion()
        {
            Name = "Обычное уклонение";
            Description = "Описание";
        }

        public void Setup(IFighter me)
        {
            me.evasion += 4;
        }

        public void Teardown(IFighter me)
        {
            me.evasion -= 4;
        }
    }
}
