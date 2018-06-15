using UnityEngine;
using UnityEngine.SceneManagement;

public enum TypeTraining { STICKTHEBAG, DANCING }
public class Training : MonoBehaviour
{ 
    public TypeTraining Type;
    /// <summary>
    /// Управление анимацией
    /// </summary>
    public Animator AnimatorController;

    /// <summary>
    /// Эффект, оказываемый на параметры
    /// </summary>
    public double EffectParam;

    private int loop = 1;
    private bool isTrain = false;
    private float actualTime = 0;

    private EffectCharact effect;
    /// <summary>
    /// Эффекты, оказываемые на характеристики
    /// </summary>
    private struct EffectCharact
    {
        /// коэффициенты, отвечающие за увеличение параметров:
        int EffectDexterity;                              ///Эффект, оказываемый на ловкость
        int EffectStamina;                                ///Эффект, оказываемый на выносливость
        int EffectPower;                                  ///Эффект, оказываемый на силу

        public EffectCharact(int dex, int stam, int pow)
        {
            EffectDexterity = dex;
            EffectStamina = stam;
            EffectPower = pow;
        }

        /// <summary>
        /// Развитие характеристик и повышение их уровня
        /// </summary>
        public void ChangeCharacteristics()
        {
            ///заполнение шкалы развития характеристик
            MainHero.Me.Stamina.Bar.Quanity += EffectStamina;
            MainHero.Me.Dexterity.Bar.Quanity += EffectDexterity;
            MainHero.Me.Power.Bar.Quanity += EffectPower;

            ///увеличение уровня характеристик
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
   
    /// <summary>
    /// Запуск тренировки и определение эффектов
    /// </summary>
    public void StartTraining()
    {
        AnimatorController = GetComponent<Animator>();
        isTrain = true;
        DoEffect();
    }

    /// <summary>
    /// Определяет эффект тренировки в зависимости от её типа
    /// </summary>
    public void DoEffect()
    {
        switch (Type)
        {
            case TypeTraining.STICKTHEBAG:
                effect = new EffectCharact(3, 2, 0);
                break;
            case TypeTraining.DANCING:
                effect = new EffectCharact(1, 1, 3);
                break;
        }
    }

    private void Update()
    {
        if (isTrain == true)
        {
            if (MainHero.Me.Energy.Quanity > 0)
            {
                actualTime += Time.deltaTime;

                if (actualTime > loop)
                {
                    loop++;

                    ///изменение параметров
                    MainHero.Me.Mood.DecreaseQuanity(EffectParam);
                    MainHero.Me.Energy.DecreaseQuanity(EffectParam);
                    MainHero.Me.Satiety.DecreaseQuanity(EffectParam);

                    ///изменение характеристик
                    effect.ChangeCharacteristics();
                }
            }
        }
        ///сбрасываем выполнение
        if (Input.GetMouseButtonDown(1))
        {
            isTrain = false;
            loop = 1;
            actualTime = 0;
        }
    }

    /// <summary>
    /// Проверка местоположения игрока
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            AnimatorController.SetTrigger("Training1");
            StartTraining();
        }
    }

    public void GoToGym(int index)
    {
        SceneManager.LoadScene(index);
    }
}
