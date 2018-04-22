﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class Fight
    {
        static Random rnd = new Random();

        /// <summary>
        /// вернуть void после тестов
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="opponent"></param>
        /// <returns></returns>
        static ISkill[] Clash(MainHero hero, FightBot opponent)
        {
            var skillHero = hero.GetSkill();
            skillHero.Setup(hero);

            var skillOpponent = opponent.GetSkill();
            skillOpponent.Setup(opponent);

            var damage = hero.attack + hero.power.value * 2;
            opponent.Damage(damage);

            damage = opponent.attack + opponent.power.value * 2;
            hero.Damage(damage);

            skillHero.Teardown(hero);

            skillOpponent.Teardown(opponent);

            ISkill[] array = { skillHero, skillOpponent };///убрать массив после тестов

            return array;///убрать после тестов
        }

        /// <param name="hero"></param>
        /// <param name="opponent"></param>
        /// <param name="winHero">счетчик побед Протагониста</param>
        /// <param name="winBot">счетчик побед Антагониста</param>
        static void Round(MainHero hero, FightBot opponent, int winHero, int winBot)
        {
            while ((hero.HP.GetQuanity() > 0) &&
                (opponent.HP.GetQuanity() > 0))
            {
                var skillsUsed = Clash(hero, opponent);///убрать массив после тестов
                DescriptionOfClash(hero, opponent, skillsUsed);///
            }

            EndOfRound(hero, opponent, winHero, winBot);
        }

        public static void Сombat(MainHero hero, FightBot opponent)
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
        static void DescriptionOfClash(MainHero hero, FightBot opponent, ISkill[] skillsUsed)
        {
            Console.WriteLine("========================================================\n" +
                                  "Протагонист: здоровье = {0}, энергия = {1}\n" +
                                  "Используемый навык: {2}",
                                  hero.HP.GetQuanity(),
                                  hero.HP.GetQuanity(),
                                  skillsUsed[0].Name);
            Console.WriteLine("--------------------------------------------------------\n" +
                              "Антагонист: здоровье = {0}, энергия = {1}\n" +
                              "Используемый навык: {2}",
                              opponent.HP.GetQuanity(),
                              opponent.HP.GetQuanity(),
                              skillsUsed[1].Name);
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
            //Console.ReadKey();
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
            if (hero.HP.GetQuanity() > opponent.HP.GetQuanity())
            {
                winHero++; return "Победил Протагонист.";
            }
            else if (hero.HP.GetQuanity() < opponent.HP.GetQuanity())
            {
                winBot++; return "Победил Антагонист.";
            }
            //else if (hero.fightEnergy.GetQuanity() > opponent.energy.GetQuanity())
            //{
            //    winHero++; return "Победил Протагонист.";
            //}
            //else if (hero.fightEnergy.GetQuanity() < opponent.energy.GetQuanity())
            //{
            //    winBot++; return "Победил Антагонист.";
            //}
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
            //Console.ReadKey();
        }

        static void SetMaximumOfParameters(MainHero hero, FightBot opponent)
        {
            hero.HP.SetQuanityMaximum();
            hero.HP.SetQuanityMaximum();
            //opponent.health.SetQuanityMaximum();
            //opponent.energy.SetQuanityMaximum();
        }
    }
}
