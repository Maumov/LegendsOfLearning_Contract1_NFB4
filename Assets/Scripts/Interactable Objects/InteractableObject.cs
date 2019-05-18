﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    Transform playerPosition;
    [Header("Interaction")]
    public Vector3 interactionOffset;
    public Vector3 colliderSize = new Vector3(1.5f, 1.5f, 1.5f);

    [Header("Indicators")]
    public GameObject canvasIndicatorPrefab;
    //public string prefabText;
    private GameObject prefabContainer;
    public bool canBeFocus = false;
    public bool isFocus;
    public bool interacted;

    private void Awake()
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.center = interactionOffset;
        collider.size = colliderSize;
        collider.isTrigger = true;
    }

    public virtual void Interaction()
    {
        interacted = true;
        // Place here the interaction behaviour
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player"))
        {
            canBeFocus = true;
            // Instanciar indicador
            if (!interacted && canvasIndicatorPrefab != null)
            {
                prefabContainer = Instantiate(canvasIndicatorPrefab);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!interacted && Input.GetAxisRaw("Interact") == 1)
        {
            Interaction();
            DestroyContainer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Player"))
        {
            canBeFocus = false;
            // Eliminar indicador
            DestroyContainer();
        }
    }

    public void DestroyContainer()
    {
        if (prefabContainer != null)
        {
            Destroy(prefabContainer);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero + interactionOffset, colliderSize);
    }
}