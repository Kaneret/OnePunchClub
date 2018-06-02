using System;
using UnityEngine;

public class TornadoKick : MonoBehaviour, ISkill
{
    public string Name { get; }

    public string Description { get; }

    public TornadoKick()
    {
        Name = "Удар Торнадо";
        Description = "Описание удара торнадо";
    }

    public void Setup(IFighter me)
    {
        me.Attack += 10;
        me.EP.DecreaseQuanity(3);
    }

    public void Teardown(IFighter me)
    {
        me.Attack -= 10;
    }
}

