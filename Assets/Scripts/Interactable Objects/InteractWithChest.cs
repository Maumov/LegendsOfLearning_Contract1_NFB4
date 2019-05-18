using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class InteractWithChest : InteractableObject
{
    public bool completed = false;
    private bool isModuleOpen = false;
    public UnityEvent StartUsingChest;

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
            else
            {
                StartUsingChest.Invoke();
            }
        }
    }

    // Cerrar module sin terminarse
    public void ExitModule()
    {
        CameraMovement.RestoreInputs();
        isModuleOpen = false;
    }

    // Llamar al completar el cofre
    public void ChestCompleted()
    {
        ExitModule();
        completed = true;
        interacted = true;
    }
}