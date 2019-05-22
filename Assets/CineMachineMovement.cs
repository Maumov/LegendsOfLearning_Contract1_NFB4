using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineMovement : MonoBehaviour
{
    public Vector3[] firstPart;
    public Vector3[] secondPart;
    public Vector3 initialRotation;
    public Vector3 finalRotation;

    public void StartPanning()
    {

        LeanTween.moveSplineLocal(gameObject, firstPart, 4f).setOnStart(SetInitialRotation).setOnComplete(StartRotating);
    }

    void StartRotating()
    {
        LeanTween.moveSplineLocal(gameObject, secondPart, 6f).setDelay(2f).setOnStart(SetFinalRotation);
    }

    void SetInitialRotation()
    {
        transform.localRotation = Quaternion.Euler(initialRotation);
    }
    void SetFinalRotation()
    {
        transform.localRotation = Quaternion.Euler(finalRotation);
    }
}