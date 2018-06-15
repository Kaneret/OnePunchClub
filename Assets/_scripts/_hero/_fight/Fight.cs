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
        skillHero.Setup(hero);
                
        var skillOpponent = opponent.GetSkill();
        skillOpponent.Setup(opponent);

        Damage(hero, CountingDamageOf(hero), opponent);
        Damage(opponent, CountingDamageOf(opponent), hero);

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
        fighter.EP.Maximum = 10 * fighter.Power.Value + 10 * fighter.Dexterity.Value;
        fighter.EP.SetQuanityMaximum();
    }

    static int CountingDamageOf(IFighter fighter)
    {
        return fighter.Attack + fighter.Power.Value * 2;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fighter">тот, кто наносит урон</param>
    /// <param name="damage">чистый, незаблокированный урон</param>
    /// <param name="opponent">тот, кто получает урон</param>
    static void Damage(IFighter fighter, int damage, IFighter opponent)
    {
        if (fighter.EP.Quanity == 0)
        {
            damage /= 2;
        }
        opponent.Damage(damage);
    }
}

