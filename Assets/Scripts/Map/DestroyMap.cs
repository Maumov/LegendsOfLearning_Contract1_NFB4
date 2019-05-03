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
        GameManager.DisableCursor();
        Destroy(transform.parent.gameObject);
    }
}