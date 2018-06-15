using UnityEngine;
using UnityEngine.UI;

public enum DifWork { SUPPLIER, BUILDER }
public class Work : MonoBehaviour
{
    public int Payment;
    public int Period;
    public double Effect;
    public DifWork Type;//?
    public Slider slider;
    public Text PaymentTitle;

    private bool isWork = false;
    private float WorkTime = 0;
    private int loop = 1;

    public GameObject Objwork;
    public GameObject Stop;

    public void StartWorking()
    {
        Stop.SetActive(true);
        isWork = true;
    }

    public void StopWorking()
    {
        isWork = false;
        Stop.SetActive(false);
    }

    public void CloseWork()
    {
        Objwork.SetActive(false);
        Stop.SetActive(false);
        slider.value = 0;
        loop = 1;
        WorkTime = 0;
        isWork = false;
    }

    public void Process()
    {
        if (WorkTime > loop)
        {
            loop++;
            MainHero.Me.Energy.DecreaseQuanity(Effect);
            MainHero.Me.Mood.DecreaseQuanity(Effect);
            MainHero.Me.Satiety.DecreaseQuanity(Effect);
        }
    }

    void Update()
    {
        PaymentTitle.text = "Каждый раз завершая работу, ты будешь получать:\n" 
                                + Payment.ToString() + "$";

        if (isWork == true)
        {
            if (MainHero.Me.Energy.Quanity > 0)
            {
                if (WorkTime < Period)
                {
                    WorkTime += Time.deltaTime;
                    slider.value = WorkTime;
                    Process();
                }
                else
                {
                    MainHero.Me.Money += Payment;
                    WorkTime = 0;
                    loop = 1;
                }
            }
        }
    }

}
