using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public void DestroyMap()
    {
        if (MiniMapController.map != null)
        {
            MiniMapController.map = null;
            Destroy(gameObject);
        }
    }
}