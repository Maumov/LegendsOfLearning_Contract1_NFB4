using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLanguageHandler : MonoBehaviour
{
    public string key;
    
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Text>().text = SharedState.LanguageDefs[key];
        //Debug.Log(SharedState.LanguageDefs[key]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
