using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class InteractWithChest : InteractableObject
{
    public bool completed = false;
    private bool isModuleOpen = false;
    public UnityEvent onStart;

    public override void Interaction()
    {
        base.Interaction();
        if (!completed && !isModuleOpen)
        {
            isModuleOpen = true;
            CameraPanning panning = GetComponent<CameraPanning>();
            if(panning != null)
            {
                panning.ActivateCinematic();
            }
            else
            {
                onStart.Invoke();
            }
        }
    }

    // Cerrar module sin terminarse
    public void ExitModule()
    {
        isModuleOpen = false;
        interacted = false;
    }

    // Llamar al completar el cofre
    public void ChestCompleted()
    {
        ExitModule();
        Destroy(this);
        //completed = true;
        //interacted = true;
    }
}