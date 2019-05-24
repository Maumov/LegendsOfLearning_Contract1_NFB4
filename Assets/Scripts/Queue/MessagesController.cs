using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesController : MonoBehaviour
{
    public TextController textPrefab;
    public GameObject canvas;

    public void SpawnText(string keyName)
    {
        canvas.SetActive(true);
        List<string> list = new List<string>();
        list.Add(SharedState.LanguageDefs[keyName]);
        if(list != null)
        {
            textPrefab.SetText(list);
        }
    }

    public void AddText(string keyName) {
        textPrefab.AddText(SharedState.LanguageDefs[keyName]);
    }
}