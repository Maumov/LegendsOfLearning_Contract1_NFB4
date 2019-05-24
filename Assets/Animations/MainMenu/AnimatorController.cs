using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator title;
    public Animator nextGame;

    public void AnimateNewGameButton()
    {
        nextGame.Play("NewGame_Init");
    }
}