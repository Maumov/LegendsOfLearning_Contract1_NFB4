using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesController : MonoBehaviour
{
    public TextController textPrefab;
    public GameObject canvas;


    public void SpawnText(Frases keyName)
    {
        canvas.SetActive(true);
        List<Frases> list = new List<Frases>();
        //list.Add(SharedState.LanguageDefs[keyName]);
        list.Add(keyName);
        if(list != null)
        {
            textPrefab.SetText(list);
        }
    }

    public void AddText(Frases keyName) {
        textPrefab.AddText(keyName);
        //textPrefab.AddText(SharedState.LanguageDefs[keyName]);
    }


}