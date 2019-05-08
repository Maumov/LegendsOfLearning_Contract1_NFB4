using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MapIconPrefab : MonoBehaviour
{
    public bool status = false;
    public int id;
    [HideInInspector] public int arrayIndex;
    public Vector2 numerators;
    public Vector2 denimators;
    public Vector2 position;

    public void ActivateIcon()
    {
        if (transform.parent.GetComponent<GridManager>().CheckForIconIndex(denimators))
        {
            RawImage image = GetComponent<RawImage>();
            image.color = new Color(1, 1, 1, 1);
            image.raycastTarget = false;

            if (MapManager.instance.audioSource != null)
            {
                MapManager.instance.audioSource.Play();
            }

            RawImage imageOrigin = MapManager.instance.icons[arrayIndex].GetComponent<RawImage>();
            imageOrigin.color = new Color(1, 1, 1, 1);
            imageOrigin.raycastTarget = false;
            imageOrigin.GetComponent<MapIconPrefab>().status = true;

            DoorsManager.SpawnDoor(id);
        }
    }
}