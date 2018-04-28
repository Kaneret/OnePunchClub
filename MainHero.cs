using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class MainHero : FightBot, IFighter
    {
        public Parameter energy;
        public Parameter mood; //настроение
        public Parameter satiety; //сытость

        public MainHero()
        {
            HP = new Parameter(20);
            energy = new Parameter(100);
            mood = new Parameter(100);
            satiety = new Parameter(100);

            activeFightSkills = new List<ISkill>();
            SetMaxSkills(2);
            SetArmor(3);

            dexterity = new Characteristic(1);
            power = new Characteristic(1);
            stamina = new Characteristic(1);

            block = 1;
            evasion = 1;
            attack = 1;
        }
    }
}
