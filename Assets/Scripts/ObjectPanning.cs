using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ObjectPanning : MonoBehaviour
{
    [Header("Object Movement")]
    public Transform[] waypoints;
    [Range(0, 120f)]
    public float movementDuration;
    LTSpline pathIntro;
    LTSpline pathEnding;

    [Header("Rotate")]
    public bool enableRotation = true;
    public GameObject target;
    public float minRotation;
    public float maxRotation;
    [Range(0, 10f)]
    public float duration;
    float RotationX;
    float RotationY;

    [Header("EndingTween")]
    public UnityEvent OnEndingCompleted;

    [Header("Events")]
    public UnityEvent OnStart;
    public UnityEvent OnComplete;

    void Start()
    {
        Vector3[] points = new Vector3[waypoints.Length];
        for (int i = 0; i < waypoints.Length; i++)
        {
            points[i] = waypoints[i].position;
        }
        pathIntro = new LTSpline(points);

        System.Array.Reverse(points);
        pathEnding = new LTSpline(points);

        if (enableRotation)
        {
            Rotation();
        }
        LeanTween.moveSpline(gameObject, pathIntro, movementDuration).setOrientToPath(true).setOnStart(OnStart.Invoke).setOnComplete(OnComplete.Invoke);
    }

    public void Rotation()
    {
        LeanTween.cancel(target);
        RotationX = Random.Range(minRotation, maxRotation);
        RotationY = Random.Range(minRotation, maxRotation);

        LeanTween.rotateX(target, RotationX, duration).setLoopPingPong(1);
        LeanTween.rotateZ(target, RotationY, duration).setLoopPingPong(1).setOnComplete(InverseRotation);

    }

    public void InverseRotation()
    {
        LeanTween.rotateX(target, -RotationX, duration).setLoopPingPong(1);
        LeanTween.rotateZ(target, -RotationY, duration).setLoopPingPong(1).setOnComplete(Rotation);
    }

    public void CompletedAnimation(float value)
    {
        LeanTween.cancel(target, true);
        duration = value;
        Rotation();
    }

    public void EndingTween()
    {
        LeanTween.moveSpline(gameObject, pathEnding, 20f).setOrientToPath(true).setOnStart(OnStart.Invoke).setOnComplete(OnEndingCompleted.Invoke);
    }

}