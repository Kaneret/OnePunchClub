using System;
using UnityEngine;

public class CommonEvasion : MonoBehaviour, ISkill
{
    public string Name { get; }

    public string Description { get; }

    public CommonEvasion()
    {
        Name = "Обычное уклонение";
        Description = "Описание";
    }

    public void Setup(IFighter me)
    {
        me.Evasion += 4;
        me.EP.DecreaseQuanity(1);
    }

    public void Teardown(IFighter me)
    {
        me.Evasion -= 4;
    }
}

