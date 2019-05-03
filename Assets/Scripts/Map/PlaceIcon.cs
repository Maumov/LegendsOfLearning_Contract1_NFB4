using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceIcon : MonoBehaviour
{
    public bool status;
    public string targetTag;
    public RectTransform UIReference;
    public Vector2 pointA;
    public Vector2 pointB;
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform;

        if (!status || target != null)
        {
            if(target.position.x < pointA.x || target.position.x > pointB.x ||
                target.position.z > pointA.y || target.position.z < pointB.y)
            {
                Debug.Log("called");
                gameObject.SetActive(false);
                return;
            }
        }

        RectTransform rTransform = GetComponent<RectTransform>();

        rTransform.eulerAngles = new Vector3(0f, 0f, -target.eulerAngles.y);

        Vector2 relativePosition = (pointB - pointA);
        relativePosition = new Vector2(Mathf.Abs(relativePosition.x), Mathf.Abs(relativePosition.y));

        Vector2 canvasPosition = new Vector2((target.position.x - pointA.x) / relativePosition.x, (target.position.z - pointA.y) / relativePosition.y);

        rTransform.anchoredPosition = new Vector2(UIReference.rect.width * canvasPosition.x, UIReference.rect.height * canvasPosition.y);
    }
}
