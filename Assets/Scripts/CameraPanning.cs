using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    [Header("Camera Settings")]
    public GameObject objectCamera;
    public GameObject mainCamera;

    [Header("Waypoints & References")]
    [Range(0f, 10f)]
    public float duration;
    public Transform waypoint;
    private InteractableObject interactableScript;
    public enum TypeOfTween { Smooth, Waypoints };
    public TypeOfTween tween = TypeOfTween.Waypoints;

    [HideInInspector] public bool isActive;
    private Vector3[] wayPoints;
    private LTSpline spline;

    private void Start()
    {
        interactableScript = GetComponent<InteractableObject>();

        if (tween == TypeOfTween.Waypoints)
        {
            wayPoints = new Vector3[waypoint.childCount];
            for (int i = 0; i < waypoint.childCount; i++)
            {
                wayPoints[i] = waypoint.GetChild(i).transform.position;
            }

            spline = new LTSpline(wayPoints);
        }
    }

    void Update()
    {
        if (isActive)
        {
            objectCamera.transform.LookAt(transform);

            if (tween == TypeOfTween.Smooth)
            {
                LeanTween.move(objectCamera, waypoint.GetChild(waypoint.childCount - 1).position, duration).setOnComplete(interactableScript.ModuleCompleted);
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
            LeanTween.moveSpline(objectCamera, spline, duration).setOnComplete(interactableScript.ModuleCompleted);
        }
    }

    public void AnimationCompleted()
    {
        isActive = false;
        mainCamera.SetActive(true);
        objectCamera.SetActive(false);
        objectCamera.transform.position = wayPoints[0];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (waypoint != null)
        {
            for (int i = 0; i < waypoint.childCount - 1; i++)
            {
                
                Gizmos.DrawLine(waypoint.GetChild(i).transform.position, waypoint.GetChild(i + 1).transform.position);
            }
        }
    }
}