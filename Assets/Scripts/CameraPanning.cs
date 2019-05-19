using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    [Header("Camera Settings")]
    public GameObject objectCamera;
    public GameObject mainCamera;
    private Vector3 cameraInitPosition;

    [Header("Waypoints & References")]
    public bool ShowGizmos;
    [Range(0f, 300f)]
    public float duration;
    public Transform waypoint;
    [HideInInspector] public InteractableObject interactableScript;
    public enum TypeOfTween { Smooth, Waypoints };
    public TypeOfTween tween = TypeOfTween.Waypoints;

    [HideInInspector] public bool isActive;
    private Vector3[] wayPoints;
    private LTSpline spline;

    [Header("Events")]
    public UnityEvent OnStart;
    public UnityEvent OnComplete;

    private void Start()
    {
        interactableScript = GetComponent<InteractableObject>();

        if (waypoint == null)
        {
            waypoint = transform;
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

    public void StartTween()
    {
        Debug.Log("Started");
    }

    public void Completed()
    {
        Debug.Log("Completed");
    }


    void Update()
    {
        if (isActive)
        {
            objectCamera.transform.LookAt(transform);

            if (tween == TypeOfTween.Smooth)
            {
                LeanTween.cancelAll();
                int id = LeanTween.move(objectCamera, waypoint.position, duration).setOnStart(OnStart.Invoke).setOnComplete(OnComplete.Invoke).setEase(LeanTweenType.easeOutQuad).id;
            }
        }
    }
    
    public void ActivateCinematic()
    {
        isActive = true;
        mainCamera.SetActive(false);
        objectCamera.SetActive(true);
        CameraMovement.StaticSetInputs(false);

        if (tween == TypeOfTween.Waypoints)
        {
            int id = LeanTween.moveSpline(objectCamera, spline, duration).setOnStart(OnStart.Invoke).setOnComplete(OnComplete.Invoke).setEase(LeanTweenType.animationCurve).id;
        }
    }

    public void AnimationCompleted()
    {
        isActive = false;
        objectCamera.SetActive(false);
        mainCamera.SetActive(true);
        CameraMovement.StaticSetInputs(true);
        objectCamera.transform.position = cameraInitPosition;
    }

    private void OnDrawGizmos()
    {
        if (ShowGizmos)
        {
            wayPoints = new Vector3[waypoint.childCount];
            for (int i = 0; i < waypoint.childCount; i++)
            {
                wayPoints[i] = waypoint.GetChild(i).transform.position;
            }

            spline = new LTSpline(wayPoints);

            Gizmos.color = Color.blue;
            if (spline != null)
                spline.gizmoDraw();
        }
    }
}