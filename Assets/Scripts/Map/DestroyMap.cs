using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyMap : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        MapManager.isMapOpen = false;
        CameraMovement.StaticSetInputs(true);
        GameManager.StaticSetCursorStatus(false);
        Destroy(transform.parent.gameObject);
    }
}