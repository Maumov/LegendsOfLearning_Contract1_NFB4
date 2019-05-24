using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaviotaBehaviour : MonoBehaviour
{
    RectTransform rect;
    public float ySpeed;
    public float xSpeed;
    int offset;
    bool trigger; 

    private void Start()
    {
        offset = Random.Range(0, 50);
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (trigger)
        {
            Debug.Log(rect.anchoredPosition.x);
        }
        rect.anchoredPosition += new Vector2(Time.deltaTime * -xSpeed, Mathf.Sin(offset + Time.time * ySpeed));

        if(rect.anchoredPosition.x <= -600)
        {
            rect.anchoredPosition = new Vector2(600, rect.anchoredPosition.y);
        }
    }

}