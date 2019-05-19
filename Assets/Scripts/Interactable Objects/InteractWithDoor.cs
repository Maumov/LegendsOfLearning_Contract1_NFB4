using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class InteractWithDoor : InteractableObject
{
    public bool completed = false;
    private bool isModuleOpen = false;

    public override void Interaction()
    {
        if (!completed && !isModuleOpen)
        {
            isModuleOpen = true;
            CameraPanning panning = GetComponent<CameraPanning>();
            if(panning != null)
            {
                panning.ActivateCinematic();
            }
        }
    }

    // Cerrar module sin terminarse
    public void ExitModule()
    {
        isModuleOpen = false;
        // Destroy(module);
    }

    public void ChestCompleted()
    {
        //ExitModule();
        //Destroy(this);
        //completed = true;
        //interacted = true;
    }
}