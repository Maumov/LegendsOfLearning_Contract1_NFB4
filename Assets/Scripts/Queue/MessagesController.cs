using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesController : MonoBehaviour
{
    public TextController textPrefab;
    public GameObject canvas;


    public void SpawnText(List<Frases> keyNames)
    {
        textPrefab.MakeUncompleted();
        
        canvas.SetActive(true);
        List<Frases> list = new List<Frases>();
        //list.Add(SharedState.LanguageDefs[keyName]);
        list.AddRange(keyNames);
        if(list != null)
        {
            textPrefab.SetText(list);
        }
    }

    //public void AddText(Frases keyName) {
    //    textPrefab.AddText(keyName);
    //    //textPrefab.AddText(SharedState.LanguageDefs[keyName]);
    //}
}