using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesController : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform canvas;

    public bool SpawnText(string ListName)
    {
        List<string> list = Library.instance.GetText(ListName);
        if(list != null)
        {
            TextController text = Instantiate(textPrefab, canvas).GetComponent<TextController>();
            text.SetText(Library.instance.GetText(ListName));
            return true;
        }
        else
        {
            Debug.Log("Didn't work");
            return false;
        }
    }
}