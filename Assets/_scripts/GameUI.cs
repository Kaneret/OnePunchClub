using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private bool OpenningWindow = false;

    public GameObject TournamentTable;
    public GameObject Map;
    public GameObject TreeofSkills;

    public void ControlMap()
    {
        if (OpenningWindow == false)
        {
            Map.SetActive(true);
            OpenningWindow = true;
        }
        else if (OpenningWindow == true)
        {
            Map.SetActive(false);
            OpenningWindow = false;
        }
    }

    public void ControlTreeofSkills()
    {
        if (OpenningWindow == false)
        {
            TreeofSkills.SetActive(true);
            OpenningWindow = true;
        }
        else if (OpenningWindow == true)
        {
            TreeofSkills.SetActive(false);
            OpenningWindow = false;
        }
    }

    public void ControlofTournamentTable()
    {
        if (OpenningWindow == false)
        {
            TournamentTable.SetActive(true);
            OpenningWindow = true;
        }
        else if (OpenningWindow == true)
        {
            TournamentTable.SetActive(false);
            OpenningWindow = false;
        }
    }
}