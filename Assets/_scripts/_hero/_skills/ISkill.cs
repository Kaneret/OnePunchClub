using System;

public interface ISkill
{
    /// <summary>
    /// убрать из интерфейса послее тестов
    /// </summary>
    /// <param name="me"></param>   
    string Name { get; }
    void Setup(IFighter me);
    void Teardown(IFighter me);
}

