using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingGame : MonoBehaviour
{
    public GameObject GameOverCanvas;

    public void LoadCanvas()
    {
        Instantiate(GameOverCanvas);
        gameObject.SetActive(false);
    }
}
