using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LocalBranch { FIRST, SECOND, THIRD, FOURTH }

public class ActiveSkills : MonoBehaviour
{
    public LocalBranch Element;
    int CheckBranch;

    public ISkill VarSkill { get; set; }
    public int Perk { get; set; }
    public int Cost { get; set; }
    public int Check { get; set; }
    public int Branch { get; set; }
    List<int> Fathers = new List<int>();

    public ActiveSkills(ISkill VarSkill, int Perk, int Cost, int Check, int Branch, List<int> Fathers)
    {
        this.VarSkill = VarSkill;
        this.Perk = Perk;
        this.Cost = Cost;
        this.Check = Check;
        this.Branch = Branch;
        this.Fathers = Fathers;
    }

    public static List<ActiveSkills> SkillList_ = new List<ActiveSkills>
    {
         new ActiveSkills(new CommonPunch(), 0, 1, 1, 1, new List<int>() { 0 }),
         new ActiveSkills(new CommonBlock(), 0, 1, 0, 1, new List<int>() { 0 }),
         new ActiveSkills(new CommonEvasion(), 0, 1, 0, 1, new List<int>() { 0 }),

         new ActiveSkills(new TornadoKick(), 0, 1, 1, 2, new List<int>() { 3 }),
         new ActiveSkills(new ExKick(), 0, 1, 0, 2, new List<int>() { 3 }),
         new ActiveSkills(new RightHighPunch(), 0, 1, 0, 2, new List<int>() { 3 }),
    };

    public void AddSkill(int index, int CheckBranch)
    {
        foreach (int Father in SkillList_[index].Fathers)
        {
            if (
            (((MainHero.Me.SkillPoints - SkillList_[index].Cost) >= 0)
            && (SkillList_[Father].Check == 1)
            && (SkillList_[Father].Branch == CheckBranch)
            && (SkillList_[index].Check != 1)
            && (SkillList_[Father].Branch == CheckBranch)))
            {
                SkillList_[index].Check = 1;
                MainHero.Me.SkillPoints -= SkillList_[index].Cost;
                MainHero.Me.AllSkills.Add(SkillList_[index].VarSkill);
            }
        }
    }
    public void ChoiceBranch(int index)
    {
        switch (Element)
        {
            case LocalBranch.FIRST:
                CheckBranch = 1;
                AddSkill(index, CheckBranch);
                break;
            case LocalBranch.SECOND:
                CheckBranch = 2;
                AddSkill(index, CheckBranch);
                break;
            case LocalBranch.THIRD:
                CheckBranch = 3;
                AddSkill(index, CheckBranch);
                break;
            case LocalBranch.FOURTH:
                CheckBranch = 4;
                AddSkill(index, CheckBranch);
                break;
        }
    }
}
