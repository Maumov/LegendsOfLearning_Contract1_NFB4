using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPanning : MonoBehaviour
{
    [Header("Object Settings")]
    public GameObject target;

    [Header("Waypoints & References")]
    public bool ShowGizmos;
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
        if (waypoint.childCount > 0)
        {
            if (tween == TypeOfTween.Waypoints)
            {
                wayPoints = new Vector3[waypoint.childCount];
                for (int i = 0; i < waypoint.childCount; i++)
                {
                    wayPoints[i] = waypoint.GetChild(i).transform.position;
                }

                spline = new LTSpline(wayPoints);

                ActivateCinematic();
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
            if (tween == TypeOfTween.Smooth)
            {
                int id = LeanTween.move(target, waypoint.position, duration).setOrientToPath(true).setEase(LeanTweenType.easeOutQuad).id;
                tweenID = LeanTween.descr(id);
            }
        }
    }

    public void ActivateCinematic()
    {
        if (tween == TypeOfTween.Waypoints)
        {
            int id = LeanTween.moveSpline(target, spline, duration).setOrientToPath(true).setEase(LeanTweenType.animationCurve).id;
            tweenID = LeanTween.descr(id);
        }
    }

    public void AnimationCompleted()
    {

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