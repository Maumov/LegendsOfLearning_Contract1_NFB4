using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public Queue<string> message;
    public TextMeshProUGUI text;
    public TextMeshProUGUI buttonText;
    bool completed;
    public float delay = 1;
    private float delayCounter;

    private void Start()
    {
        delayCounter = delay;
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
                text.text = message.Dequeue();
                if (message.Count == 0)
                {
                    completed = true;
                    buttonText.text = "OK";
                }
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Completed");
            }

            delayCounter = delay;
        }
    }

    public void SetText(List<string> data)
    {
        message = new Queue<string>(data);
        text.text = message.Dequeue();
    }

    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}