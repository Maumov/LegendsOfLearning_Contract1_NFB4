using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineMovement : MonoBehaviour
{
    public GameObject ship;
    public Vector3[] firstPart;
    public Vector3[] secondPart;
    public Vector3 initialRotation;
    public Vector3 finalRotation;

    public void StartPanning()
    {

        LeanTween.moveSplineLocal(gameObject, firstPart, 4f).setOnStart(SetInitialRotation).setOnComplete(SecondPanning);
    }

    void SecondPanning()
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

    public void SetShipRotation()
    {
        ship.transform.rotation = Quaternion.Euler(ship.transform.rotation.x, 102.12f, ship.transform.rotation.z);
    }
}