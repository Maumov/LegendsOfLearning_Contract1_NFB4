using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenedor : MonoBehaviour
{
    public float minValue;
    public float maxValue;
    public float currentValue;
    public float animationSpeed = 1f;
    float valueAnimated;


    private void Update() {
        valueAnimated = Mathf.Lerp(valueAnimated, currentValue, Time.deltaTime * animationSpeed);
    }

    public void SetValue(float value) {
        currentValue = value;
    }
    
}
