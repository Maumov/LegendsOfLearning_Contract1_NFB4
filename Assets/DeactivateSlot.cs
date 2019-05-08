using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateSlot : MonoBehaviour
{
    public int id;
    void Start()
    {
        for(int i = 0; i < DoorsManager.completed.Count; i++)
        {
            if(id == DoorsManager.completed[i].id)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
