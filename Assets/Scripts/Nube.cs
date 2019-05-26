using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nube : MonoBehaviour
{
    RectTransform rect;
    public float speed;
    public float amplitud;
    float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = Random.Range(-30, 30);
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.anchoredPosition += new Vector2(Mathf.Sin(offset + Time.time * speed) * amplitud, 0f);
    }
}
