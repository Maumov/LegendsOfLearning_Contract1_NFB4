using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLanguageHandler : MonoBehaviour
{
    public string key;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(SharedState.LanguageDefs[key]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
