using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStart : MonoBehaviour
{
    public AnimatorController controller;

    public void StartNewGameAnimation()
    {
        controller.AnimateNewGameButton();
    }
}