using System;
using UnityEngine;

public class ExKick : MonoBehaviour, ISkill
{
    public string Name { get; }

    public string Description { get; }

    public ExKick()
    {
        Name = "Экс Удар";
        Description = "Экс Описание";
    }

    public void Setup(IFighter me)
    {
        me.Attack += 15;
        me.EP.DecreaseQuanity(2);
    }

    public void Teardown(IFighter me)
    {
        me.Attack -= 15;
    }
}

