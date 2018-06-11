using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public static float GameSeconds;
    public static float GameMinutes;
    public static float GameDays;

    public Text TextTime;

    void Update()
    {
        GameSeconds = GameSeconds + Time.deltaTime;

        TextTime.text = "День:" + GameDays.ToString() + "\n" + 
            "Время:" + GameMinutes.ToString() + ":" + GameSeconds.ToString();

        if (GameSeconds >= 60.0f)
        {
            GameMinutes = GameMinutes + 1.0f;
            GameSeconds = 0.0f;
        }

        if (GameMinutes >= 24.0f)
        {
            GameDays = GameDays + 1.0f;
            GameMinutes = 0.0f;
        }
    }
}
