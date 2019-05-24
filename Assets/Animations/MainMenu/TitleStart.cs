using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStart : MonoBehaviour
{
    public Animator nextGame;

    public void AnimateNewGameButton()
    {
        nextGame.Play("NewGame_Init");
    }
}