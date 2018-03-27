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
        private int quanityAFS;

        public Parameter fightEnergy;
        public double regenFE;

        private int armor;
        public double precision; //точность в бою

        public Characteristic dexterity;//ловкость
        public Characteristic power;//сила
        public Characteristic stamina;//выносливость

        public void Bring()
        {
            int bring = 100;
            energy = new Parameter(bring);
            health = new Parameter(bring);
            mood = new Parameter(bring);
            satiety = new Parameter(bring);            

            quanityAFS = 2;

            fightEnergy = new Parameter(bring);
            regenFE = 0;

            armor = 0;
            precision = 0.5;

            dexterity = new Characteristic(1, 100, 0);
            power = new Characteristic(1, 100, 0);
            stamina = new Characteristic(1, 100, 0);
        }

        void SetQuanityAFS(int quan) { quanityAFS = quan; }

        int GetQuanityAFS() => quanityAFS;

        void SetArmor(int armor) { this.armor = armor; }

        int GetArmor() => armor;
    }
}
