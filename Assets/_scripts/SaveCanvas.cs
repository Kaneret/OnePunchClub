using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveCanvas : MonoBehaviour {

    public static SaveCanvas SC { get; private set; }
    public Canvas Canvas;
    public GameObject GO;


    private void Awake()
    {
        if (SC == null)
        {
            SC = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
