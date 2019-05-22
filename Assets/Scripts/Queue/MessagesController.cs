using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesController : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform canvas;


    public void SpawnText(string ListName)
    {
        List<string> list = Library.instance.GetText(ListName);
        if(list != null)
        {
            TextController text = Instantiate(textPrefab, canvas).GetComponentInChildren<TextController>();
            text.SetText(list);
        }
        else
        {
            Debug.Log("Didn't work");
        }
    }
}