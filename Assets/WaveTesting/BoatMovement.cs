using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [Range(0, 30f)]
    public int xRotationRange;
    [Range(0f, 30f)]
    public int zRotationRange;
    public int duration;
    ObjectPanning panning;
    float xRotation;
    float zRotation;
    LTDescr xDesc;
    LTDescr zDesc;

    void Start()
    {
        SetAngles();
        LeanTween.rotateAround(gameObject, transform.forward, xRotation, duration).setOnComplete(SetAngles).setOnCompleteOnRepeat(true).setLoopPingPong();
        LeanTween.rotateAround(gameObject, transform.right, zRotation, duration).setOnComplete(SetAngles).setOnCompleteOnRepeat(true).setLoopPingPong();
    }

    private void SetAngles()
    {
        xRotation = Random.Range(-xRotationRange, xRotationRange);
        zRotation = Random.Range(-zRotationRange, zRotationRange);
    }
}