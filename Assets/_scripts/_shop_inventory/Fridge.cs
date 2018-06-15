using UnityEngine;
using UnityEngine.UI;

public class Fridge : MonoBehaviour
{
    public GameObject Obj;

    public GameObject Bananas;
    public GameObject Meat;
    public GameObject Milk;
    public GameObject Pizza;

    public Text CountofBananas;
    public Text CountofMeat;
    public Text CountofMilk;
    public Text CountofPizza;


    public void OpenElement()
    {
        Obj.SetActive(true);
    }

    public void UpdateFood(GameObject button, Text text)
    {
        var food = button.GetComponent<Food>();
        text.text = "x" + food.Quantity;
        button.SetActive(food.Quantity > 0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Obj.SetActive(false);
        }
        UpdateFood(Bananas, CountofBananas);
        UpdateFood(Meat, CountofMeat);
        UpdateFood(Milk, CountofMilk);
        UpdateFood(Pizza, CountofPizza);
    }


}
