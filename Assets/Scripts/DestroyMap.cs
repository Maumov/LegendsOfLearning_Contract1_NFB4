using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyMap : MonoBehaviour
{
    public void DestroyObject()
    {
        MapManager.isMapOpen = false;
        CameraMovement.RestoreInputs();
        Destroy(transform.parent.gameObject);
    }
}