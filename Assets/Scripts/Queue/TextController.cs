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
    public bool completed;
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
            if(eventoActual != null) {
                eventoActual.Invoke();
            }
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
            }
            else
            {
                CameraMovement.StaticSetInputs(true);
                MapManager.StaticSetMapStatus(true);
                
                TurnOffThisObject();
            }

            delayCounter = delay;
        }

    }

    public void SetText(List<Frases> data)
    {
        eventoActual = null;
        completed = false;
        message = new Queue<Frases>(data);
        buttonText.text = SharedState.LanguageDefs["next"];
        UpdateMessage();
        
        //string word = message.Dequeue().key;
        //text.text = SharedState.LanguageDefs[word];
    }

    public void AddText(Frases data) {
        message.Enqueue(data);
    }


    public void TurnOffThisObject()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void MakeUncompleted()
    {
        completed = false;
    }

    bool doorCompleted;
    public void DoorTutorial(bool rightAnswer)
    {
        if(doorCompleted == false)
        {
            if(rightAnswer == true)
            {
                FindObjectOfType<Guion>().StartPuertaFeedBackPos();
            }
            else if(rightAnswer == false)
            {
                FindObjectOfType<Guion>().StartPuertaFeedBackNeg();
            }

        }
    }

    public void Modulo1Tutorial()
    {

    }

    public void Modulo2Tutorial()
    {

    }

    public void Modulo3Tutorial()
    {

    }
}