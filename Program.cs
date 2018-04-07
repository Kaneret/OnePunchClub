using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    class Program
    {
        static readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            var hero = new MainHero();
            var opponent = new FightBot();

            hero.activeFightSkills.Add(new CommonPunch());
            hero.activeFightSkills.Add(new CommonBlock());

            opponent.activeFightSkills.Add(new CommonPunch());
            hero.activeFightSkills.Add(new CommonEvade());

            Сombat(hero, opponent);
        }

        static void Clash(MainHero hero, FightBot opponent)
        {
            var chanceHero = rnd.Next(1, hero.GetQuanityAFS()) - 1;
            if (chanceHero < 0) chanceHero = 0;
            var heroSkill = hero.activeFightSkills[chanceHero];
            hero.usedSkill = heroSkill;

            var chanceOpp = rnd.Next(1, opponent.GetQuanityAFS()) - 1;
            if (chanceOpp < 0) chanceOpp = 0;
            var oppSkill = opponent.activeFightSkills[chanceOpp];
            opponent.usedSkill = oppSkill;

            if ((oppSkill.Attack == true) && (heroSkill.Attack == true))
            {
                var damage = Math.Max(oppSkill.Execute(opponent) - hero.GetArmor(), 0);
                hero.fightHealth.DecreaseQuanity(damage);

                damage = Math.Max(heroSkill.Execute(hero) - opponent.GetArmor(), 0);
                opponent.health.DecreaseQuanity(damage);
            }

            if ((oppSkill.Attack == true) && (heroSkill.Block == true))
            {
                var damage = Math.Max(
                    oppSkill.Execute(opponent) -
                    (hero.GetArmor() + heroSkill.Execute(hero))
                    , 0);
                hero.fightHealth.DecreaseQuanity(damage);
            }

            if ((oppSkill.Block == true) && (heroSkill.Attack == true))
            {
                var damage = Math.Max(
                    heroSkill.Execute(hero) -
                    (opponent.GetArmor() + oppSkill.Execute(opponent))
                    , 0);
                opponent.health.DecreaseQuanity(damage);
            }

            if ((oppSkill.Attack == true) && (heroSkill.Evade == true))
            {
                if (heroSkill.Execute(hero) == 0)
                {
                    var damage = Math.Max(oppSkill.Execute(opponent) - hero.GetArmor(), 0);
                    hero.fightHealth.DecreaseQuanity(damage);
                }
                else heroSkill.Execute(hero);
            }

            if ((oppSkill.Evade == true) && (heroSkill.Attack == true))
            {
                if (oppSkill.Execute(opponent) == 0)
                {
                    var damage = Math.Max(heroSkill.Execute(hero) - opponent.GetArmor(), 0);
                    opponent.health.DecreaseQuanity(damage);
                }
                else oppSkill.Execute(opponent);
            }

            if (((oppSkill.Block == true) || (oppSkill.Evade == true))
                && ((heroSkill.Block == true) || (heroSkill.Evade == true)))
            {
                heroSkill.Execute(hero);
                oppSkill.Execute(opponent);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="opponent"></param>
        /// <param name="winHero">счетчик побед Протагониста</param>
        /// <param name="winBot">счетчик побед Антагониста</param>
        static void Round(MainHero hero, FightBot opponent, int winHero, int winBot)
        {
            while ((hero.fightHealth.GetQuanity() > 0) ||
                (hero.fightEnergy.GetQuanity() > 0) ||
                (opponent.health.GetQuanity() > 0) ||
                (opponent.energy.GetQuanity() > 0))
            {
                Clash(hero, opponent);
                DescriptionOfClash(hero, opponent);
            }

            EndOfRound(hero, opponent, winHero, winBot);
        }

        static void Сombat(MainHero hero, FightBot opponent)
        {   
            ///счетчики побед         
            int winHero = 0;
            int winBot = 0;
            
            for (int i = 0; i < 12; i++)
            {
                SetMaximumOfParameters(hero, opponent);
                BeginOfRound(i + 1);
                Round(hero, opponent, winHero, winBot);
            }
            EndOfCombat(winHero, winBot);
            SetMaximumOfParameters(hero, opponent);
        }
        
        /// <summary>
        /// только для прототипа
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="opponent"></param>
        static void DescriptionOfClash(MainHero hero, FightBot opponent)
        {
            Console.WriteLine("========================================================\n" +
                                  "Протагонист: здоровье = {0}, энергия = {1}\n" +
                                  "Используемый навык: {2}",
                                  hero.fightHealth.GetQuanity(),
                                  hero.fightEnergy.GetQuanity(),
                                  hero.usedSkill.Name);
            Console.WriteLine("--------------------------------------------------------\n" +
                              "Антагонист: здоровье = {0}, энергия = {1}\n" +
                              "Используемый навык: {2}",
                              opponent.health.GetQuanity(),
                              opponent.energy.GetQuanity(),
                              opponent.usedSkill.Name);
        }

        /// <summary>
        /// только для прототипа
        /// </summary>
        /// <param name="number"></param>
        static void BeginOfRound(int number)
        {
            Console.WriteLine("\n\nРаунд {0}.\n", number);
        }

        /// <summary>
        /// только для прототипа
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="opponent"></param>
        /// <param name="winHero"></param>
        /// <param name="winBot"></param>
        static void EndOfRound(MainHero hero, FightBot opponent, int winHero, int winBot)
        {
            Console.WriteLine("========================================================\n" +
                    "Раунд окончен. {0}\n" +
                    "Для продолжения нажмите любую клавишу.", 
                    GetWinnerOfRound(hero, opponent, winHero, winBot));
            Console.ReadKey();
        }

        /// <summary>
        /// только для прототипа
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="opponent"></param>
        /// <param name="winHero"></param>
        /// <param name="winBot"></param>
        /// <returns></returns>
        static string GetWinnerOfRound(MainHero hero, FightBot opponent, int winHero, int winBot)
        {
            if (hero.fightHealth.GetQuanity() > opponent.health.GetQuanity())
            {
                winHero++; return "Победил Протагонист.";
            }
            else if (hero.fightHealth.GetQuanity() < opponent.health.GetQuanity())
            {
                winBot++; return "Победил Антагонист.";
            }
            else if (hero.fightEnergy.GetQuanity() > opponent.energy.GetQuanity())
            {
                winHero++; return "Победил Протагонист.";
            }
            else if (hero.fightEnergy.GetQuanity() < opponent.energy.GetQuanity())
            {
                winBot++; return "Победил Антагонист.";
            }
            else return "Ничья.";
        }

        /// <summary>
        /// только для прототипа
        /// </summary>
        /// <param name="winHero"></param>
        /// <param name="winBot"></param>
        static void EndOfCombat(int winHero, int winBot)
        {
            if (winHero > winBot)
                Console.WriteLine("Победитель боя - Протагонист!");
            else if (winHero < winBot)
                Console.WriteLine("Победитель боя - Антагонист!");
            else Console.WriteLine("В бою победителя нет! Ничья по очкам!");
            Console.WriteLine("Для продолжения нажмите любую клавишу.");
            Console.ReadKey();
        }

        static void SetMaximumOfParameters(MainHero hero, FightBot opponent)
        {
            hero.fightHealth.SetQuanityMaximum();
            hero.fightEnergy.SetQuanityMaximum();
            opponent.health.SetQuanityMaximum();
            opponent.energy.SetQuanityMaximum();
        }
    }
}
