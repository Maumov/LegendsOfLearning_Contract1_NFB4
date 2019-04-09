using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    Transform playerPosition;
    [Header("Interaction")]
    public Transform InteractionPosition;
    [Range(0.1f, 10f)]
    public float radius = 1.5f;

    [Header("Indicators")]
    public bool canBeFocus = true;
    public bool isFocus;
    public bool interacted;

    private void Awake()
    {
        if (InteractionPosition == null)
            InteractionPosition = gameObject.transform;
    }

    public virtual void Interaction()
    {
        // Place here the interaction behaviour
    }

    // For Chest and etc
    public virtual void StartModule()
    {
        // Instantiate module
    }

    public virtual void ModuleCompleted()
    {
        // Complete module
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        if (InteractionPosition != null)
        {
            Gizmos.DrawWireSphere(InteractionPosition.position, radius);
        }
        else
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}