using System;
using UnityEngine;

public class CommonBlock : MonoBehaviour, ISkill
{
    public string Name { get; }

    public string Description { get; }

    public CommonBlock()
    {
        Name = "Обычный блок";
        Description = "Описание";
    }

    public void Setup(IFighter me)
    {
        me.Block += 4;
        me.EP.DecreaseQuanity(1);
    }

    public void Teardown(IFighter me)
    {
        me.Block -= 4;
    }
}

