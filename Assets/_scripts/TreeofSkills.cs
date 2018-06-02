using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeofSkills : MonoBehaviour
{
    private bool OpenningWindow = false;

    public GameObject Trees;
    public GameObject ScrollBasicWay;
    public GameObject Scroll1Way;
    public GameObject Scroll2Way;
    public GameObject Scroll3Way;

    public void ShowBasicWay()
    {
        if (OpenningWindow == false)
        {
            ScrollBasicWay.SetActive(true);
            OpenningWindow = true;
        }
        else if (OpenningWindow == true)
        {
            ScrollBasicWay.SetActive(false);
            OpenningWindow = false;
        }
    }

    public void Show1Way()
    {
        if (OpenningWindow == false)
        {
            Scroll1Way.SetActive(true);
            OpenningWindow = true;
        }
        else if (OpenningWindow == true)
        {
            Scroll1Way.SetActive(false);
            OpenningWindow = false;
        }
    }

    public void Show2Way()
    {
        if (OpenningWindow == false)
        {
            Scroll2Way.SetActive(true);
            OpenningWindow = true;
        }
        else if (OpenningWindow == true)
        {
            Scroll2Way.SetActive(false);
            OpenningWindow = false;
        }
    }

    public void Show3Way()
    {
        if (OpenningWindow == false)
        {
            Scroll3Way.SetActive(true);
            OpenningWindow = true;
        }
        else if (OpenningWindow == true)
        {
            Scroll3Way.SetActive(false);
            OpenningWindow = false;
        }
    }

    public void DoExit()
    {
        Trees.SetActive(false);
    }


}
