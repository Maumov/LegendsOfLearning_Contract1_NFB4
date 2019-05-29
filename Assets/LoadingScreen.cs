using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public GameObject mainMenuCanvas;

    public void ChangeLevel(string sceneName)
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            if(mainMenuCanvas != null)
            {
                gameObject.SetActive(true);
            }
        }
        StartCoroutine(LoadBackgroundScene(sceneName));
    }

    IEnumerator LoadBackgroundScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}