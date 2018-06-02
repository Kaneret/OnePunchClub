using System;
using UnityEngine;

public class CommonPunch : MonoBehaviour, ISkill
{
    public string Name { get; }

    public string Description { get; }

    public CommonPunch()
    {
        Name = "Удар кулаком";
        Description = "Описание";
    }

    public void Setup(IFighter me)
    {
        me.Attack += 4;
        me.EP.DecreaseQuanity(2);
    }

    public void Teardown(IFighter me)
    {
        me.Attack -= 4;
    }
}

