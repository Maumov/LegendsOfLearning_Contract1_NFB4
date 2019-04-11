using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public void DestroyMap()
    {
        MiniMapController.isMapOpen = false;
        CameraMovement.RestoreInputs();
        Destroy(transform.parent.gameObject);
    }
}