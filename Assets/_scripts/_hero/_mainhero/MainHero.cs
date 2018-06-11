using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MainHero : FightBot, IFighter
{
    public static MainHero Me { get; private set; }

    public Parameter Health;
    public Parameter Energy;
    public Parameter Mood; //настроение 
    public Parameter Satiety; //сытость 

    public List<ISkill> AllSkills { get; set; }
    public int SkillPoints;
    public int Money;

    /// шкалы заполненности и текстовые отображения 
    /// параметров и характеристик
    /// (интерфейс пользователя)
    public Slider SliderHp;
    public Slider SliderEnergy;
    public Slider SliderMood;
    public Slider SliderSatiety;
    public Text CountMoney;
    public Text CountPoints;
    public Text CountPointsTree;//?

    public Slider SliderDexterity;
    public Slider SliderPower;
    public Slider SliderStamina;
    public Text CountDexterity;
    public Text CountPower;
    public Text CountStamina;

    public MainHero()
    {
        Health = new Parameter(100);
        Energy = new Parameter(100);
        Mood = new Parameter(100);
        Satiety = new Parameter(100);

        AllSkills = new List<ISkill>();

        SkillPoints = 3;
        Money = 1000;

        HP = new Parameter(20);
        EP = new Parameter(20);
        ActiveFightSkills = new List<ISkill>();
        MaxQuanityAFS = 2;
        Armor = 3;

        Dexterity = new Characteristic(1);
        Power = new Characteristic(1);
        Stamina = new Characteristic(1);

        Block = 1;
        Evasion = 1;
        Attack = 1;
    }

    private void Awake()
    {
        if (Me == null)
        {
            Me = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        SliderHp.value = Health.Quanity;
        SliderEnergy.value = Energy.Quanity;
        SliderMood.value = Mood.Quanity;
        SliderSatiety.value = Satiety.Quanity;

        CountMoney.text = Money.ToString() + "$";
        CountPoints.text = SkillPoints.ToString();
        CountPointsTree.text = SkillPoints.ToString();

        SliderDexterity.value = Dexterity.Bar.Quanity;
        SliderPower.value = Power.Bar.Quanity;
        SliderStamina.value = Stamina.Bar.Quanity;

        CountDexterity.text = Dexterity.Value.ToString();
        CountPower.text = Power.Value.ToString();
        CountStamina.text = Stamina.Value.ToString();


    }
}