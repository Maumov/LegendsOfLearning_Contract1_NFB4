using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySlots : MonoBehaviour
{
    public GameObject slot;
    public GridManager IconList;
    public Transform destinationPoint;

    private void Start()
    {
        for(int i= 0; i < IconList.icons.Count; i++)
        {
            SlotController temp = Instantiate(slot, destinationPoint).GetComponent<SlotController>();
            temp.SetSlot(IconList.icons[i]);
        }
    }
}