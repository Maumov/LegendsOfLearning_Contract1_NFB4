using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CineMachineMovement : MonoBehaviour
{
    public GameObject ship;
    public Transform refencePoint;
    public Vector3[] firstPart;
    public Vector3[] secondPart;
    public Vector3 finalRotation;
    CinemachineVirtualCamera virtualCamera;
    public float delay;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void StartPanning()
    {
        LeanTween.cancel(gameObject, true);
        LeanTween.moveSplineLocal(gameObject, firstPart, 6f).setOnStart(SetShipRotation).setOnComplete(SecondPanning);
    }

    void SecondPanning()
    {
        transform.rotation = Quaternion.Euler(32f, 85f, 0f);
        DisableLookAt();
        LeanTween.moveSplineLocal(gameObject, secondPart, 4f).setDelay(2f).setOnStart(SetFinal).setOnComplete(LookAtShip);
    }

    void LookAtTreasure()
    {
        virtualCamera.LookAt = refencePoint;
    }

    void DisableLookAt()
    {
        virtualCamera.LookAt = null;
    }

    void LookAtShip()
    {
        virtualCamera.LookAt = ship.transform;
    }

    void SetFinal()
    {
        transform.rotation = Quaternion.Euler(finalRotation);
        ship.GetComponent<ObjectPanning>().EndingTween();
        StartCoroutine(lookat());
    }

    public void SetShipRotation()
    {
        LookAtTreasure();
        ship.transform.rotation = Quaternion.Euler(ship.transform.rotation.x, -5f, ship.transform.rotation.z);
    }

    IEnumerator lookat()
    {
        yield return new WaitForSeconds(delay);
        LookAtShip();
        yield break;
    }
}