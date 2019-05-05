using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPanning : MonoBehaviour
{
    [Header("Object Movement")]
    public Transform[] waypoints;
    [Range(0, 120f)]
    public float movementDuration;
    LTSpline path;
    public LTDescr tweenID;

    [Header("Rotate")]
    public bool enableRotation = true;
    public GameObject target;
    public float minRotation;
    public float maxRotation;
    [Range(0, 10f)]
    public float duration;
    float RotationX;
    float RotationY;

    void Start()
    {
        Vector3[] points = new Vector3[waypoints.Length];
        for (int i = 0; i < waypoints.Length; i++)
        {
            points[i] = waypoints[i].position;
        }
        path = new LTSpline(points);

        if (enableRotation)
        {
            Rotation();
        }
        tweenID = LeanTween.descr(LeanTween.moveSpline(gameObject, path, movementDuration).setOrientToPath(true).id);
    }

    public void Rotation()
    {
        LeanTween.cancel(target);
        RotationX = Random.Range(minRotation, maxRotation);
        RotationY = Random.Range(minRotation, maxRotation);

        LeanTween.rotateX(target, RotationX, duration).setLoopPingPong(1).setOnComplete(InverseRotation);
        LeanTween.rotateZ(target, RotationY, duration).setLoopPingPong(1).setOnComplete(InverseRotation);

    }

    public void InverseRotation()
    {
        LeanTween.rotateX(target, -RotationX, duration).setLoopPingPong(1).setOnComplete(Rotation);
        LeanTween.rotateZ(target, -RotationY, duration).setLoopPingPong(1).setOnComplete(Rotation);
    }

    public void CompletedAnimation(float value)
    {
        LeanTween.cancel(gameObject, true);
        duration = value;
        Rotation();
    }
}