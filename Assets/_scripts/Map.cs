using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ObjMap { HOME, SHOP, BUILD, DELIVERY }
public class Map : MonoBehaviour
{
    public ObjMap element;
    public int ByBus;
    public int ByFoot;

    public Text Name;
    public Text DistanceBus;
    public Text DistanceFoot;

    public GameObject MapJpg;
    public GameObject objChoice;
    public GameObject objBuild;
    public GameObject objDelivery;

    public void StartMovement()
    {
        ShowElement();
    }

    public void DoMovement()
    {
        switch (element)
        {
            case ObjMap.HOME:
                GotoHome(1);
                break;
            case ObjMap.SHOP:
                GotoShop(2);
                break;
            case ObjMap.DELIVERY:
                objChoice.SetActive(false);
                objDelivery.SetActive(true);
                break;
            case ObjMap.BUILD:
                objChoice.SetActive(false);
                objBuild.SetActive(true);
                break;
        }
    }

    public void GotoHome(int sceneIndex)
    {
        MapJpg.SetActive(false);
        objChoice.SetActive(false);
        SceneManager.LoadScene(sceneIndex);
    }

    public void GotoShop(int sceneIndex)
    {
        MapJpg.SetActive(false);
        objChoice.SetActive(false);
        SceneManager.LoadScene(sceneIndex);
    }

    public void ShowElement()
    {
        objChoice.SetActive(true);
    }

    public void MovementByBus()
    {
        MainHero.Me.Money -= ByBus;
        DoMovement();
    }

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
