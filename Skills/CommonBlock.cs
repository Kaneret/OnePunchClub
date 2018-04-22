﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class CommonBlock : ISkill
    {
        public string Name { get; }

        public string Description { get; }

        public CommonBlock()
        {
            Name = "Обычный блок";
            Description = "Описание";
        }

        public void Setup(IFighter me)
        {
            me.block += 4;
        }

        public void Teardown(IFighter me)
        {
            me.block -= 4;
        }
    }
}
