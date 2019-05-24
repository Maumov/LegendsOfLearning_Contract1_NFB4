using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ola : MonoBehaviour
{
    RectTransform rect;
    public float speed = 3;
    int offset;
    Vector2 defaultPosition;
    public float scaleSpeed;
    float xScale;

    private void Start()
    {
        offset = Random.Range(-10, 10);
        rect = GetComponent<RectTransform>();
        defaultPosition = new Vector2(rect.anchoredPosition.x, rect.parent.GetComponent<RectTransform>().anchoredPosition.y);
        xScale = rect.localScale.x;
    }

    public void ResetPosition()
    {
        rect.anchoredPosition = defaultPosition;
        rect.localScale = new Vector3(rect.localScale.x * 0.5f, 1f, 1f);
    }

    private void Update()
    {
        if(rect.localScale.x < xScale * 1.2)
        {
            rect.localScale += new Vector3(Time.deltaTime * scaleSpeed, 0, 0);
        }

        rect.anchoredPosition += new Vector2(0f , Time.deltaTime * -speed);

        if (rect.anchoredPosition.y <= -320)
        {
            ResetPosition();
        }
    }
}
