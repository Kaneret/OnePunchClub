using System;
using UnityEngine;

public class RightHighPunch : MonoBehaviour, ISkill
{
    public string Name { get; }

    public string Description { get; }

    public RightHighPunch()
    {
        Name = "Высокий Удар кулаком";
        Description = "Описание Высокий Удар кулаком";
    }

    public void Setup(IFighter me)
    {
        me.Attack += 25;
        me.EP.DecreaseQuanity(2);
    }

    public void Teardown(IFighter me)
    {
        me.Attack -= 25;
    }
}

