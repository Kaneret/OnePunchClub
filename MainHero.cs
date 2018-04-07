using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class MainHero
    {
        public Parameter energy;
        public Parameter health;
        public Parameter mood; //настроение
        public Parameter satiety; //сытость

        public List<ISkill> activeFightSkills { get; set; }

        public ISkill usedSkill;/// <summary>
        /// используется только в прототипе
        /// </summary>

        private int quanityAFS;

        public Parameter fightEnergy;
        public Parameter fightHealth;
        public double regenFE;

        private int armor;
        public double precision; //точность в бою

        public Characteristic dexterity;//ловкость
        public Characteristic power;//сила
        public Characteristic stamina;//выносливость

        public MainHero()
        {
            energy = new Parameter(100);
            health = new Parameter(100);
            mood = new Parameter(100);
            satiety = new Parameter(100);

            activeFightSkills = new List<ISkill>();
            quanityAFS = 2;

            fightEnergy = energy;
            fightHealth = health;
            regenFE = 0;

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
