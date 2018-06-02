using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    public GameObject ButtonLoad;
    public GameObject ButtonNewGame;
    public GameObject ButtonExit;
    public GameObject SliderLoad;
    public Slider Slider;

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        ButtonLoad.SetActive(false);
        ButtonNewGame.SetActive(false);
        ButtonExit.SetActive(false);
        SliderLoad.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Slider.value = progress;
            yield return null;
        }

    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);

    }

    public void Exit()
    {
        Application.Quit();
    }
}
