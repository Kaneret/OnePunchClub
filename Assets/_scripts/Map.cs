using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ObjMap { HOME = 1, SHOP, BUILD, DELIVERY }
public class Map : MonoBehaviour
{
    public ObjMap Type;

    /// <summary>
    /// Кол-во денег, которое потратим на автобус
    /// </summary>
    public int ByBus;
    /// <summary>
    /// Кол-во времени, которое потратим на перемещение пешком
    /// </summary>
    public int ByFoot;

    /// <summary>
    /// Название места, куда переместимся
    /// </summary>
    public Text Name;
    /// <summary>
    /// Значение ByBus в виде текста в игре
    /// </summary>
    public Text DistanceBus;
    /// <summary>
    /// Значение ByFoot в виде текста в игре
    /// </summary>
    public Text DistanceFoot;

    public GameObject MapJpg;
    /// <summary>
    /// Окно выбора способа перемещения
    /// </summary>
    public GameObject objChoice;
    /// <summary>
    /// Окно работы - стройка
    /// </summary>
    public GameObject objBuild;
    /// <summary>
    /// Окно работы - доставка
    /// </summary>
    public GameObject objDelivery;

    /// <summary>
    /// Открытие окна способа перемещения 
    /// </summary>
    public void StartMovement()
    {
        objChoice.SetActive(true);
    }

    /// <summary>
    /// Обрабатывает выбор игрока и запускает перемещение
    /// </summary>
    private void DoMovement()
    {
        switch (Type)
        {
            case ObjMap.HOME:
                GotoScene((int)ObjMap.HOME);
                break;
            case ObjMap.SHOP:
                GotoScene((int)ObjMap.SHOP);
                break;
            case ObjMap.BUILD:
                GotoBuild();
                break;
            case ObjMap.DELIVERY:
                GotoDelivery();
                break;
        }
    }

    /// <summary>
    /// Закрывает все открытые окна и загружает сцену
    /// </summary>
    /// <param name="sceneIndex">HOME = 1, SHOP = 2</param>
    private void GotoScene(int sceneIndex)
    {
        MapJpg.SetActive(false);
        objChoice.SetActive(false);
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// Закрывает окно выбора перемещения и открывает окно работы
    /// </summary>
    private void GotoDelivery()
    {
        objChoice.SetActive(false);
        objDelivery.SetActive(true);
    }

    /// <summary>
    /// Закрывает окно выбора перемещения и открывает окно работы
    /// </summary>
    private void GotoBuild()
    {
        objChoice.SetActive(false);
        objBuild.SetActive(true);
    }

    /// <summary>
    /// Влияние на героя: 
    /// Уменьшает кол-во денег
    /// </summary>
    public void MovementByBus()
    {
        MainHero.Me.Money -= ByBus;
        DoMovement();
    }

    /// <summary>
    /// Влияние на героя:
    /// Увеличивает игровое время
    /// Уменьшает параметры (настроение, сытость, энергия)
    /// </summary>
    public void MovementByFoot()
    {
        GameTimer.GameMinutes += ByFoot;
        MainHero.Me.Satiety.Quanity -= ByFoot * 3;
        MainHero.Me.Mood.Quanity -= ByFoot * 2;
        MainHero.Me.Energy.Quanity -= ByFoot * 4;
        DoMovement();
    }

    public void Update()
    {
        DistanceBus.text = ByBus.ToString();
        DistanceFoot.text = ByFoot.ToString();
    }

    public void Close()
    {
        objChoice.SetActive(false);
    }
}
