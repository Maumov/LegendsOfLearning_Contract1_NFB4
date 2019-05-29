using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    [Header("Camera Settings")]
    public GameObject objectCamera;
    private Vector3 cameraInitPosition;
    public Transition transition;

    [Header("Waypoints & References")]
    public bool ShowGizmos;
    [Range(0f, 300f)]
    public float duration;
    public float durationBetweenModules;
    public Transform waypoint;
    public Transform[] referencePointsModule;
    Vector3[] path = new Vector3[4];

    [HideInInspector] public bool isActive;
    private Vector3[] wayPoints;
    private LTSpline spline;

    [Header("Events")]
    public UnityEvent OnStart;
    public UnityEvent OnComplete;

    private void Start()
    {
        if (waypoint == null)
        {
            waypoint = transform;
        }

        cameraInitPosition = objectCamera.transform.position;

        if(waypoint.childCount > 0)
        {
                wayPoints = new Vector3[waypoint.childCount];
                for (int i = 0; i < waypoint.childCount; i++)
                {
                    wayPoints[i] = waypoint.GetChild(i).transform.position;
                }

                spline = new LTSpline(wayPoints);
        }
    }

    public void ActivateCinematic()
    {
        isActive = true;
        objectCamera.SetActive(true);
        LeanTween.moveSpline(objectCamera, spline, duration).setOnStart(OnStart.Invoke).setOnUpdate(LookAtObjectDoor).setOnComplete(TweenModulo1).setEase(LeanTweenType.animationCurve);
    }

    public void LookAtObjectDoor(float x)
    {
        objectCamera.transform.LookAt(transform.position);
    }

    public void TweenModulo1()
    {
        path[0] = objectCamera.transform.position;
        path[1] = objectCamera.transform.position;
        path[2] = referencePointsModule[0].position;
        path[3] = referencePointsModule[0].position;

        LTSpline newSpline = new LTSpline(path);

        LeanTween.moveSpline(objectCamera, newSpline, durationBetweenModules).setOnComplete(TweenModulo2).setEase(LeanTweenType.animationCurve);
    }

    public void TweenModulo2()
    {
        path[0] = objectCamera.transform.position;
        path[1] = objectCamera.transform.position;
        path[2] = referencePointsModule[1].position;
        path[3] = referencePointsModule[1].position;

        LTSpline newSpline = new LTSpline(path);

        LeanTween.moveSpline(objectCamera, newSpline, durationBetweenModules).setOnComplete(TweenModulo3);
    }

    public void TweenModulo3()
    {
        path[0] = objectCamera.transform.position;
        path[1] = objectCamera.transform.position;
        path[2] = referencePointsModule[2].position;
        path[3] = referencePointsModule[2].position;

        LTSpline newSpline = new LTSpline(path);

        LeanTween.moveSpline(objectCamera, newSpline, durationBetweenModules).setOnComplete(LeanTweenCompleted);
    }

    public void LookAtObjectModulo1()
    {
        objectCamera.transform.LookAt(referencePointsModule[0]);
    }
    public void LookAtObjectModulo2()
    {
        objectCamera.transform.LookAt(referencePointsModule[1]);
    }
    public void LookAtObjectModulo3()
    {
        objectCamera.transform.LookAt(referencePointsModule[2]);
    }

    public void LeanTweenCompleted()
    {
        transition.transform.parent.gameObject.SetActive(true);
        transition.ActivateTransition();
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(0.5f);
        objectCamera.transform.position = cameraInitPosition;
        OnComplete.Invoke();
        yield break;
    }

    public void AnimationCompleted()
    {
        isActive = false;
        objectCamera.SetActive(false);
       
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