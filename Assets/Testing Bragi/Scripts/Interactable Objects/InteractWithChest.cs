using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithChest : InteractableObject
{
    public bool completed = false;
    private bool isModuleOpen = false;
    LTTesting test;

    Animator objectAnimator;
    [Range(0.5f, 2)]
    public string OpenStringTrigger;

    private void Start()
    {
        objectAnimator = GetComponent<Animator>();
        test = GetComponent<LTTesting>();
    }

    public override void Interaction()
    {
        if (!completed && !isModuleOpen)
        {
            interacted = true;
            isModuleOpen = true;
            // Instantiate module;
            test.SetCinematic();
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