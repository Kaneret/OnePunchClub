using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnePunchClub;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var hero = new MainHero();
        //    var opponent = new FightBot();

        //    Fight.Сombat(hero, opponent);
        //}

        [TestMethod]
        public void TestMethod2()
        {
            var hero = new MainHero();
            var opponent = new FightBot();

            hero.activeFightSkills.Add(new CommonPunch());

            opponent.activeFightSkills.Add(new CommonPunch());

            Fight.Сombat(hero, opponent);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var hero = new MainHero();
            var opponent = new FightBot();

            hero.activeFightSkills.Add(new CommonPunch());
            hero.activeFightSkills.Add(new CommonBlock());

            opponent.activeFightSkills.Add(new CommonPunch());
            opponent.activeFightSkills.Add(new CommonEvade());

            Fight.Сombat(hero, opponent);
        }
    }
}
