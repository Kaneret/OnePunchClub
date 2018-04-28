using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class FightBot : IFighter
    {
        public Parameter HP;
        private int armor;

        public int block { get; set; }
        public int evasion { get; set; }
        public int attack { get; set; }

        public List<ISkill> activeFightSkills { get; set; }
        private int maxQuanityAFS;
        //public ISkill usedSkill;

        public Characteristic dexterity;
        public Characteristic power;
        public Characteristic stamina;

        private Random rnd { get { return new Random(); } }

        public FightBot()
        {
            HP = new Parameter(20);

            activeFightSkills = new List<ISkill>();
            maxQuanityAFS = 2;
            armor = 3;

            dexterity = new Characteristic(1);
            power = new Characteristic(1);
            stamina = new Characteristic(1);

            block = 1;
            evasion = 1;
            attack = 1;
        }

        public void SetMaxSkills(int quan) { maxQuanityAFS = quan; }

        public int GetMaxSkills() { return maxQuanityAFS; }

        public void SetArmor(int armor) { this.armor = armor; }

        public int GetArmor() { return armor; }

        //public int GetDexterity() { return dexterity.value; }

        //public int GetPower() { return power.value; }

        //public int GetStamina() { return stamina.value; }

        public ISkill GetSkill()
        {
            var chance = rnd.Next(0, activeFightSkills.Count);
            var usedSkill = activeFightSkills[chance];            
            return usedSkill;
        }

        public void Damage(int damage)
        {
            if (rnd.NextDouble() > (evasion + dexterity.value) / 40)
            {
                var dam = damage - (block + stamina.value + armor);
                if (dam < 0) dam = 0;
                HP.DecreaseQuanity(dam);
            }
        }
    }
}
