using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextController : MonoBehaviour
{
    public Queue<Frases> message;
    public TextMeshProUGUI text;
    public TextMeshProUGUI buttonText;
    bool completed;
    public float delay = 1;
    private float delayCounter;

    UnityEvent eventoActual;

    private void Start()
    {
        delayCounter = delay;
        CameraMovement.StaticSetInputs(false);
        GameManager.StaticSetCursorStatus(true);
        MapManager.StaticSetMapStatus(false);
    }

    private void Update()
    {
        if(delayCounter > 0)
        {
            delayCounter -= Time.deltaTime;
        }

        if(Input.GetAxisRaw("Interact") == 1)
        {
            UpdateMessage();
        }
    }

    public void UpdateMessage()
    {
        if(delayCounter <= 0)
        {
            if (!completed)
            {
                eventoActual = message.Peek().evento;
                string word = message.Dequeue().key;
                text.text = SharedState.LanguageDefs[word];
                if (message.Count == 0)
                {
                    completed = true;
                    buttonText.text = SharedState.LanguageDefs["ok"];
                }
                eventoActual.Invoke();
            }
            else
            {
                CameraMovement.StaticSetInputs(true);
                MapManager.StaticSetMapStatus(true);
                
                DestroyThisObject();
            }

            delayCounter = delay;
        }
    }

    public void SetText(List<Frases> data)
    {
        buttonText.text = SharedState.LanguageDefs["next"];
        message = new Queue<Frases>(data);
        string word = message.Dequeue().key;
        text.text = SharedState.LanguageDefs[word];
    }

    public void AddText(Frases data) {
        message.Enqueue(data);
    }


    public void DestroyThisObject()
    {
        transform.parent.gameObject.SetActive(false);
        //stroy(transform.parent.gameObject);
    }
}