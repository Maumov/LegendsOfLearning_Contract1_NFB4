using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesController : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform canvas;


    public void SpawnText(string keyName)
    {
        List<string> list = new List<string>();
        list.Add(SharedState.LanguageDefs[keyName]);
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