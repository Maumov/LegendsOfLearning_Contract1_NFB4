using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceScaling : MonoBehaviour {

    public GameObject renderObject;

    public float minDistance, maxDistance;

    public float scalingAmount;

    private float initialXSize;
    private float initialYSize;

    private float normalizedDistance;

    private float scaledAmount;

    private float scaledXSize;
    private float scaledYSize;

    private float dist;

	// Use this for initialization
	void Start () {

        initialXSize = renderObject.GetComponent<Renderer>().material.GetFloat("_LineXSize");
        initialXSize = renderObject.GetComponent<Renderer>().material.GetFloat("_LineYSize");

    }
	
	// Update is called once per frame
	void Update () {

        dist = Vector3.Distance(this.transform.position, renderObject.transform.position);

        if (dist < minDistance) {
            normalizedDistance = 0;
        }
        else
        {
            normalizedDistance = dist / maxDistance;
        }

        scaledAmount = scalingAmount * normalizedDistance;

        scaledXSize = (initialXSize + scaledAmount);
        scaledYSize = (initialYSize + scaledAmount);

        renderObject.GetComponent<Renderer>().material.SetFloat("_LineXSize", scaledXSize);
        renderObject.GetComponent<Renderer>().material.SetFloat("_LineYSize", scaledYSize);

    }
}
