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
    GridManager gridManager;
    bool TutorialFinished;

    public void ActivateIcon()
    {
        gridManager = transform.parent.GetComponent<GridManager>();
        if (gridManager.CheckForIconIndex(denimators))
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
            if (id == 1)
            {
                gridManager.FinishedTutorial();
            }
        }
    }

    public void ActivateMask()
    {
        gridManager = transform.parent.GetComponent<GridManager>();
        if (gridManager.CheckForIconIndex(denimators))
        {
            MapManager.instance.doorsIndicatorMask.Add(id);
            if (gridManager != null)
            {
                gridManager.slots[id - 1].ActivateMask();
            }
        } 
    }
}