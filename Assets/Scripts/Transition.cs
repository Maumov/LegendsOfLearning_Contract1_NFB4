using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Animator animator;

    public void ActivateTransition()
    {
        animator.Play("TransitionDoor");
    }

    public void DeactivateParent()
    {
        transform.parent.gameObject.SetActive(false);
        Debug.Log("Was deactivated");
    }
}
