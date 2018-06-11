

public interface IFighter
{
    string Name { get; set; }

    int Block { get; set; }
    int Evasion { get; set; }
    int Attack { get; set; }
    int Armor { get; set; }

    Characteristic Dexterity { get; set; }
    Characteristic Power { get; set; }
    Characteristic Stamina { get; set; }

    Parameter EP { get; set; }
    Parameter HP { get; set; }

    ISkill GetSkill();
    void Damage(int damage);
}

