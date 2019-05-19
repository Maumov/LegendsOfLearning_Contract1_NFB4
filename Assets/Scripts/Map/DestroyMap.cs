using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyMap : MonoBehaviour
{
    public void DestroyObject()
    {
        MapManager.isMapOpen = false;
        CameraMovement.StaticSetInputs(true);
        GameManager.StaticSetCursorStatus(false);
        Destroy(transform.parent.gameObject);
    }
}