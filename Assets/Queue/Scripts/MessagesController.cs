using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesController : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform canvas;

    private void Start()
    {
        // Prueba
        SpawnText("Antonio");
    }
    public bool SpawnText(string ListName)
    {
        List<string> list = Library.instance.GetText(ListName);
        Debug.Log(list.Count);
        if(list != null)
        {
            TextController text = Instantiate(textPrefab, canvas).GetComponentInChildren<TextController>();
            text.SetText(list);
            return true;
        }
        else
        {
            Debug.Log("Didn't work");
            return false;
        }
    }
}