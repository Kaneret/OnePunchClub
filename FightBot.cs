using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class FightBot
    {
        public Parameter HP;
        public int armor;
        public double precision;

        public int block;
        public double evasion;
        public int attack;

        public List<ISkill> activeFightSkills { get; set; }
        private int maxQuanityAFS;

        public Characteristic dexterity;
        public Characteristic power;
        public Characteristic stamina;

        Random rnd { get { return new Random(); } }

        public FightBot()
        {
            HP = new Parameter(100);

            activeFightSkills = new List<ISkill>();
            maxQuanityAFS = 2;
            armor = 10;
            precision = 0.5;

            dexterity = new Characteristic(1, 100, 0);
            power = new Characteristic(1, 100, 0);
            stamina = new Characteristic(1, 100, 0);

            block = 1;
            evasion = 0.1;
            attack = 1;
        }

        public void SetMaxSkills(int quan) { maxQuanityAFS = quan; }

        public int GetMaxSkills() { return maxQuanityAFS; }

        public void SetArmor(int armor) { this.armor = armor; }

        public int GetArmor() { return armor; }

        public ISkill GetSkill()
        {
            return activeFightSkills[rnd.Next(0, activeFightSkills.Count)];
        }

        public void Damage(int damage)
        {

        }
    }
}
