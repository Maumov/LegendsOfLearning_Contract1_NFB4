using System.Collections;
using System.Collections.Generic;
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
            panning.ActivateCinematic();
            // Iniciar animacion hacia el cofre
        }
    }

    public override void StartModule()
    {
        // Instantiate module;
    }

    // Cerrar module sin terminarse
    public void ExitModule()
    {
        isModuleOpen = false;
        // Destroy(module);
    }

    public override void ModuleCompleted()
    {
        ExitModule();
        completed = true;
        // Acciones pendientes por el modulo
        // Destroy(module);
    }
}