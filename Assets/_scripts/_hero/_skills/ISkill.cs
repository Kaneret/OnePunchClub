using System;

public interface ISkill
{
    string Name { get; }
    void Setup(IFighter me);
    void Teardown(IFighter me);
}

