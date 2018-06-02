using System;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    public Text Counts;
    public GameObject Obj;

    public int NumberRound;
    public int TimeRound;
    float ActualTime = 0;
    int loop = 1;
    bool IsFight = false;

    public IFighter Hero { get; set; }
    public IFighter Opponent { get; set; }

    static void Clash(IFighter hero, IFighter opponent)
    {        
        var skillHero = hero.GetSkill();
        var attackH = hero.Attack;
        skillHero.Setup(hero);
                
        var skillOpponent = opponent.GetSkill();
        var attackO = opponent.Attack;
        skillOpponent.Setup(opponent);

        Damage(hero, attackH, CountingDamageOf(hero), opponent);
        Damage(opponent, attackO, CountingDamageOf(opponent), hero);

        skillHero.Teardown(hero);
        skillOpponent.Teardown(opponent);
    }

    void Update()
    {
        if (IsFight)
        {
            if ((NumberRound < 12) && (Hero.HP.Quanity > 0) && (Opponent.HP.Quanity > 0))
            {
                if (ActualTime < TimeRound)
                {
                    ActualTime += Time.deltaTime;
                    if (ActualTime > loop)
                    {
                        loop++;
                        Clash(Hero, Opponent);
                    }
                }
                else
                {
                    EndofRound();
                }
            }
        }
    }

    void EndofRound()
    {
        Obj.SetActive(true);
        IsFight = false;
        NumberRound++;
        loop = 1;
        ActualTime = 0;
    }

    private void Start()
    {
        CountingHPof(Hero);
        CountingEPof(Hero);
        CountingHPof(Opponent);
        CountingEPof(Opponent);
    }

    void StartFight()
    {
        Obj.SetActive(false);
        IsFight = true; 
    }

    static void CountingHPof(IFighter fighter)
    {
        fighter.HP.Maximum = 10 * fighter.Power.Value + 10 * fighter.Stamina.Value;
        fighter.HP.SetQuanityMaximum();
    }

    static void CountingEPof(IFighter fighter)
    {
        fighter.HP.Maximum = 10 * fighter.Power.Value + 10 * fighter.Dexterity.Value;
        fighter.HP.SetQuanityMaximum();
    }

    static int CountingDamageOf(IFighter fighter)
    {
        return fighter.Attack + fighter.Power.Value * 2;
    }

    static void Damage(IFighter fighter, int attack, int damage, IFighter opponent)
    {
        if (fighter.EP.Quanity == 0)
        {
            damage /= 2;
        }
        opponent.Damage(damage);
    }
}

