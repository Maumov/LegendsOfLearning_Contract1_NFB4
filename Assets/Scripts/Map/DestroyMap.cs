using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyMap : MonoBehaviour
{
    private void Start()
    {
        CameraMovement.StaticSetInputs(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        CameraMovement.StaticSetInputs(true);
        MapManager.isMapOpen = false;
        CameraMovement.StaticSetInputs(true);
        GameManager.StaticSetCursorStatus(false);
        transform.parent.gameObject.SetActive(false);
        MapManager.isMapOpen = false;
        MapManager.StaticSetMapStatus(true);
    }
}