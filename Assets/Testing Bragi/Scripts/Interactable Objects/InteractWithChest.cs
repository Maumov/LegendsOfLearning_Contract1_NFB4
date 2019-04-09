using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithChest : InteractableObject
{
    public bool completed = false;
    private bool isModuleOpen = false;

    Animator objectAnimator;
    [Range(0.5f, 2)]
    public float delayToClose;
    public string OpenStringTrigger;

    private void Start()
    {
        objectAnimator = GetComponent<Animator>();
    }

    public override void Interaction()
    {
        if (!completed && !isModuleOpen)
        {
            interacted = true;
            isModuleOpen = true;
            CompletedModule();
            // Instantiate module;
        }
    }

    public void OpenChest()
    {
        objectAnimator.SetTrigger(OpenStringTrigger);
    }

    public void CompletedModule()
    {
        completed = true;
        // module.exit
        OpenChest();
    }
}