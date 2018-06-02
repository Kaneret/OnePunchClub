using UnityEngine;

public enum Prod { MILK, BANANAS, PIZZA, MEAT }
public class Food : MonoBehaviour
{
    public int Bonus;
    public int Price;
    public Prod Type;
    public int Quantity = 0;

    public void Buy()
    {
        if (MainHero.Me.Money - Price >= 0)
        {
            MainHero.Me.Money -= Price;
            Quantity += 1; 
        }
    }
    public void Use()
    {
        Quantity -= 1;
        MainHero.Me.Health.RestoreQuanity(Bonus);
        MainHero.Me.Mood.RestoreQuanity(Bonus);
        MainHero.Me.Energy.RestoreQuanity(Bonus);
        MainHero.Me.Satiety.RestoreQuanity(Bonus);
    }
   
}
