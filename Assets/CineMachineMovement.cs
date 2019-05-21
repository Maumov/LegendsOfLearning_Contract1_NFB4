using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineMovement : MonoBehaviour
{
    public Vector3[] panning;

    public void StartPanning()
    {
        LeanTween.moveSpline(gameObject, panning, 4f).setOnComplete(StartRotating);
    }

    void StartRotating()
    {
        LeanTween.rotateAround(gameObject, Vector3.up, -120f, 8f);
    }
}
