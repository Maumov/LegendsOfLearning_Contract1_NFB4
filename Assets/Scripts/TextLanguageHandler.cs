using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextLanguageHandler : MonoBehaviour
{
    public string key;
    
    // Start is called before the first frame update
    void Start()
    {
        Text textObject = GetComponent<Text>();
        if(textObject != null)
        {
            //textObject.text = SharedState.LanguageDefs[key];
        }
        else
        {
            TextMeshProUGUI textMesh = GetComponent<TextMeshProUGUI>();
            if(textMesh != null)
            {
               //textMesh.text = SharedState.LanguageDefs[key];
            }
            else
            {
                Debug.Log("Unable to continue");
            }
        }

        //Debug.Log(SharedState.LanguageDefs[key]);
    }
}
