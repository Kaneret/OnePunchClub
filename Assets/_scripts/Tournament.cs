using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tournament : MonoBehaviour {

    public GameObject ScrollViewMembers;
    public GameObject ScrollViewMatches;

    public bool isActive = true;


    public void SwitchScrolls()
    {
        if (isActive == true)
        {
            ScrollViewMembers.SetActive(false);
            ScrollViewMatches.SetActive(true);
            isActive = false;
        }
        else
        {
            ScrollViewMatches.SetActive(false);
            ScrollViewMembers.SetActive(true);
            isActive = true;
        }
    }

}
