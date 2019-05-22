using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateSlot : MonoBehaviour
{
    public int id;
    public GameObject mask;

    void Start()
    {
        for(int i = 0; i < DoorsManager.completed.Count; i++)
        {
            if(id == DoorsManager.completed[i].id)
            {
                gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < MapManager.instance.doorsIndicatorMask.Count; i++)
        {
            if (id == MapManager.instance.doorsIndicatorMask[i])
            {
                mask.SetActive(true);
            }
        }
    }

    public void ActivateMask()
    {
        mask.SetActive(true);
    }
}