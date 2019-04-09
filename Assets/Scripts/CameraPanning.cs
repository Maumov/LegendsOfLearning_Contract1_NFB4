﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class CameraPanning : MonoBehaviour
{
    [Header("Camera Settings")]
    public GameObject objectCamera;
    public GameObject mainCamera;
    private Vector3 cameraInitPosition;

    [Header("Waypoints & References")]
    [Range(0f, 10f)]
    public float duration;
    public Transform waypoint;
    [HideInInspector] public InteractableObject interactableScript;
    public enum TypeOfTween { Smooth, Waypoints };
    public TypeOfTween tween = TypeOfTween.Waypoints;

    [HideInInspector] public bool isActive;
    private Vector3[] wayPoints;
    private LTSpline spline;
    public LTDescr tweenID;

    private void Start()
    {
        interactableScript = GetComponent<InteractableObject>();

        if (waypoint == null)
        {
            waypoint = interactableScript.InteractionPosition;
        }

        if (waypoint.childCount <= 0)
        {

        }
        cameraInitPosition = objectCamera.transform.position;

        if(waypoint.childCount > 0)
        {
            if (tween == TypeOfTween.Waypoints)
            {
                wayPoints = new Vector3[waypoint.childCount];
                for (int i = 0; i < waypoint.childCount; i++)
                {
                    wayPoints[i] = waypoint.GetChild(i).transform.position;
                }

                spline = new LTSpline(wayPoints);
            }

            if (tween == TypeOfTween.Smooth)
            {
                waypoint.position = waypoint.GetChild(waypoint.childCount - 1).position;
            }
        }
        else
        {
            if (tween == TypeOfTween.Waypoints)
            {
                tween = TypeOfTween.Smooth;
                return;
            }
        }
    }

    void Update()
    {
        if (isActive)
        {
            objectCamera.transform.LookAt(transform);

            if (tween == TypeOfTween.Smooth)
            {
                int id = LeanTween.move(objectCamera, waypoint.position, duration).setEase(LeanTweenType.easeOutQuad).id;
                tweenID = LeanTween.descr(id);
            }
        }
    }

    public void ActivateCinematic()
    {
        isActive = true;
        objectCamera.SetActive(true);
        mainCamera.SetActive(false);

        if (tween == TypeOfTween.Waypoints)
        {
            int id = LeanTween.moveSpline(objectCamera, spline, duration).setEase(LeanTweenType.animationCurve).id;
            tweenID = LeanTween.descr(id);
        }
    }

    public void AnimationCompleted()
    {
        isActive = false;
        mainCamera.SetActive(true);
        objectCamera.SetActive(false);

        objectCamera.transform.position = cameraInitPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (waypoint != null)
        {
            
            if(waypoint.childCount > 0)
            {
                for (int i = 0; i < waypoint.childCount - 1; i++)
                {
                    Gizmos.DrawLine(waypoint.GetChild(i).transform.position, waypoint.GetChild(i + 1).transform.position);
                }
            }
        }
    }
}