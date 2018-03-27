using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class FightBot
    {
        public Parameter energy { get; }
        public Parameter health { get; }

        public List<ISkill> ativeFightSkills { get; set; }
        private int quanityAFS;

        public int armor;
        public double precision;

        public Characteristic dexterity;
        public Characteristic power;
        public Characteristic stamina;
    }
}
