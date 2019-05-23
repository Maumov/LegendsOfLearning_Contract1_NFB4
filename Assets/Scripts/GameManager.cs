using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Text gemsCounter;
    int gems;
    public GameObject finalPlaceHolder;
    public delegate void GemCounter();
    public static GemCounter counter;
    public GameObject GameOverCanvas;
    public GameObject treasure;
    public PlayableDirector director;
    public ObjectPanning shipPanning;
    public GameObject canvasPointer;

    private void Start()
    {
        CursorStatus(false);
        counter += UpdateGemsCounter;
    }

    public void UpdateGemsCounter()
    {
        if(gems <= 5)
        {
            gems++;
            gemsCounter.text = gems.ToString() + "/4";
        }
        if(gems == 4)
        {
            finalPlaceHolder.SetActive(false);
        }
    }

    public static void StaticSetCursorStatus(bool status)
    {
        Cursor.visible = status;
    }

    public void CursorStatus(bool status)
    {
        Cursor.visible = status;
        canvasPointer.SetActive(!status);
    }

    public void GameOver()
    {
        director.gameObject.SetActive(true);
        treasure.SetActive(true);
        shipPanning.EndingTween();
        director.Play();
    }

    public void LoadCanvas()
    {
        Instantiate(GameOverCanvas);
    }
}