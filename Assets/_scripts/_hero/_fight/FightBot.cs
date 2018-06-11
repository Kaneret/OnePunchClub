using System.Collections.Generic;
using UnityEngine;

public class FightBot : MonoBehaviour, IFighter
{
    public string Name { get; set; }

    public Parameter HP { get; set; }
    public Parameter EP { get; set; }
    public int Armor { get; set; }

    public int Block { get; set; }
    public int Evasion { get; set; }
    public int Attack { get; set; }

    public List<ISkill> ActiveFightSkills { get; set; }
    public int MaxQuanityAFS { get; set; }

    public Characteristic Dexterity { get; set; }
    public Characteristic Power { get; set; }
    public Characteristic Stamina { get; set; }

    public FightBot()
    {
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

    public FightBot(string name,int hp, int ep, int armor, int dexterity, int power, int stamina,
        int block, int evasion, int attack, int quanityAFS, List<ISkill> afs)
    {
        Name = name;

        HP = new Parameter(hp);
        EP = new Parameter(ep);

        ActiveFightSkills = afs;
        MaxQuanityAFS = quanityAFS;
        Armor = armor;

        Dexterity = new Characteristic(dexterity);
        Power = new Characteristic(power);
        Stamina = new Characteristic(stamina);

        Block = block;
        Evasion = evasion;
        Attack = attack;
    }

    static FightBot[] Tournament = new FightBot[]
    {
        new FightBot("Jack",20,20,3,1,1,1,1,1,1,2,new List<ISkill>(/**/)),
        new FightBot("Jack",20,20,3,1,1,1,1,1,1,2,new List<ISkill>(/**/)),
        new FightBot("Jack",20,20,3,1,1,1,1,1,1,2,new List<ISkill>(/**/)),
        new FightBot("Jack",20,20,3,1,1,1,1,1,1,2,new List<ISkill>(/**/)),
        new FightBot("Jack",20,20,3,1,1,1,1,1,1,2,new List<ISkill>(/**/)),
        new FightBot("Jack",20,20,3,1,1,1,1,1,1,2,new List<ISkill>(/**/)),
        new FightBot("Jack",20,20,3,1,1,1,1,1,1,2,new List<ISkill>(/**/)),
        new FightBot("Jack",20,20,3,1,1,1,1,1,1,2,new List<ISkill>(/**/)),
        new FightBot("Jack",20,20,3,1,1,1,1,1,1,2,new List<ISkill>(/**/)),
        new FightBot("Jack",20,20,3,1,1,1,1,1,1,2,new List<ISkill>(/**/)),
        new FightBot("Jack",20,20,3,1,1,1,1,1,1,2,new List<ISkill>(/**/)),
        new FightBot("Jack",20,20,3,1,1,1,1,1,1,2,new List<ISkill>(/**/))
    };

    public ISkill GetSkill()
    {
        var max = ActiveFightSkills.Count;
        var chance = UnityEngine.Random.Range(0, max * 50);

        return ActiveFightSkills[chance % max];
    }

    public void Damage(int damage)
    {
        if (UnityEngine.Random.value > (Evasion + Dexterity.Value) / 40)
        {
            var dam = damage - (Block + Stamina.Value + Armor);

            if (dam < 0)
            {
                dam = 0;
            }
            HP.DecreaseQuanity(dam);
        }
    }
}

