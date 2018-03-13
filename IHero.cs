using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public interface IHero
    {
        Endurance endurance { get; } //выносливость для работы
        Health health { get; }
        Mood mood { get; } //настроение
        Satiety satiety { get; } //сытость      

        ActiveSlots ativeSlots { get; }
        Armor armor { get; }
        Energy energy { get; }
        EnergyRegen eReg { get; }
        Hitpoints hp { get; } //очки здоровья в бою
        Precision precision { get; } //точность в бою

        Dexterity dexterity { get; } //ловкость
        Power power { get; } //сила
        Stamina stamina { get; } //выносливость для боя
    }
}
