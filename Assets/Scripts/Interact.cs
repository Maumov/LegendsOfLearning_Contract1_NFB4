using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask interactMask;
    public InteractableObject PreviousTarget;

    void Update()
    {
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 50f, interactMask))
            {
                InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
                if (interactable != null)
                {
                    if (interactable.canBeFocus)
                    {
                        RemoveFocus();
                        InteractWithTarget(interactable);
                    }
                }
            }
        }
    }

    void InteractWithTarget(InteractableObject target)
    {
        PreviousTarget = target;
        PreviousTarget.Interaction();
    }

    void RemoveFocus()
    {
        PreviousTarget = null;
    }
}
