using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask interactMask;
    public InteractableObject currentTarget;

    void Update()
    {
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 50f, interactMask))
            {
                InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
                if (interactable != null)
                {
                    if (interactable.canBeFocus)
                    {
                        RemoveFocus();
                        if(Vector3.Distance(transform.position, interactable.InteractionPosition.position) < interactable.radius)
                        {
                            FocusTarget(interactable);
                        }
                        else
                        {
                            Debug.Log("Not closed enough");
                            // Insertar codigo para mover al personaje hasta el punto de interaccion del cofre, si se desea.
                        }
                    }
                }
            }
        }
    }

    void FocusTarget(InteractableObject target)
    {
        currentTarget = target;
        currentTarget.Interaction();
    }

    void RemoveFocus()
    {
        currentTarget = null;
    }
}
