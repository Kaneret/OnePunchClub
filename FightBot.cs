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
        public double regenEnergy;

        public List<ISkill> activeFightSkills { get; set; }

        public ISkill usedSkill;/// <summary>
        /// используется только в прототипе
        /// </summary>

        private int quanityAFS;

        public int armor;
        public double precision;

        public Characteristic dexterity;
        public Characteristic power;
        public Characteristic stamina;

        public FightBot()
        {
            energy = new Parameter(100);
            health = new Parameter(100);
            regenEnergy = 0;

            activeFightSkills = new List<ISkill>();
            quanityAFS = 2;
            
            armor = 10;
            precision = 0.5;

            dexterity = new Characteristic(1, 100, 0);
            power = new Characteristic(1, 100, 0);
            stamina = new Characteristic(1, 100, 0);
        }

        public void SetQuanityAFS(int quan) { quanityAFS = quan; }

        public int GetQuanityAFS() => quanityAFS;

        public void SetArmor(int armor) { this.armor = armor; }

        public int GetArmor() => armor;
    }
}
