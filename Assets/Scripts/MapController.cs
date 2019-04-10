using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public void DestroyMap()
    {
        MiniMapController.isMapOpen = false;
        Destroy(transform.parent.gameObject);
    }
}