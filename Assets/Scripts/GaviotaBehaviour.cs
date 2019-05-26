using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaviotaBehaviour : MonoBehaviour
{
    RectTransform rect;
    public float ySpeed;
    public float xSpeed;
    public float amplitud = 1.0f;
    public int resetPaloma;
    float offset;
    bool trigger; 

    private void Start()
    {
        offset = Random.Range(0f, 360f);
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rect.anchoredPosition += new Vector2(Time.deltaTime * -xSpeed, Mathf.Sin(Mathf.Deg2Rad * (offset + Time.time * ySpeed)) * amplitud);

        if(rect.anchoredPosition.x <= -resetPaloma)
        {
            rect.anchoredPosition = new Vector2(resetPaloma, rect.anchoredPosition.y);
        }
    }
}