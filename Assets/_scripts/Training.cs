using UnityEngine;
using UnityEngine.SceneManagement;

public enum DifTraining { STICKTHEBAG, DANCING }
public class Training : MonoBehaviour
{ 
   
    public GameObject DoorToBackgroung;
    
    public DifTraining Element;

    public Animator _animatorController;

    /*экземпляр структуры эффектов, оказываемых на характеристики*/
    EffectParam DoChange;
    public struct EffectParam
    {
        int EffectDexterity;
        int EffectStamina;
        int EffectPower;

        public EffectParam(int a, int b, int c)
        {
            EffectDexterity = a;
            EffectStamina = b;
            EffectPower = c;
        }

        public void ChangeParam()
        {

            MainHero.Me.Stamina.Bar.Quanity += EffectStamina;
            MainHero.Me.Dexterity.Bar.Quanity += EffectDexterity;
            MainHero.Me.Power.Bar.Quanity += EffectPower;

            /*увеличение уровня характеристик*/
            if (MainHero.Me.Stamina.Bar.Quanity >= 100)
            {
                MainHero.Me.Stamina.Value += 1;
                MainHero.Me.Stamina.Bar.Quanity = 0;
            }
            if (MainHero.Me.Dexterity.Bar.Quanity >= 100)
            {
                MainHero.Me.Dexterity.Value += 1;
                MainHero.Me.Dexterity.Bar.Quanity = 0;
            }
            if (MainHero.Me.Power.Bar.Quanity >= 100)
            {
                MainHero.Me.Power.Value += 1;
                MainHero.Me.Power.Bar.Quanity = 0;
            }

        }

    }
    public double EffectCharact;

    public int loop = 1;
    bool isTrain = false;
    public float ActualTime;

    public void StartTraining()
    {
        _animatorController = GetComponent<Animator>();
        isTrain = true;
        DoEffect();
    }

    public void DoEffect()
    {
        switch (Element)
        {
            case DifTraining.DANCING:
                DoChange = new EffectParam(1, 1, 3);
                break;
            case DifTraining.STICKTHEBAG:
                DoChange = new EffectParam(3, 2, 0);
                break;
        }
    }

    private void Update()
    {
        if (isTrain == true)
        {
            if (MainHero.Me.Energy.Quanity > 0)
            {
                ActualTime += Time.deltaTime;

                if (ActualTime > loop)
                {
                    loop++;

                    /*изменение характеристик*/
                    MainHero.Me.Mood.DecreaseQuanity(EffectCharact);
                    MainHero.Me.Energy.DecreaseQuanity(EffectCharact);
                    MainHero.Me.Satiety.DecreaseQuanity(EffectCharact);

                    /*изменение параметров*/
                    DoChange.ChangeParam();
                }
            }
        }
        /*сбрасываем выполнение*/
        if (Input.GetMouseButtonDown(1))
        {
            isTrain = false;
            loop = 1;
            ActualTime = 0;
        }
    }

    /*проверка местоположения игрока*/
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            _animatorController.SetTrigger("Training1");
            StartTraining();
        }
    }

    public void GoToGym(int index)
    {
        SceneManager.LoadScene(index);
    }

}
