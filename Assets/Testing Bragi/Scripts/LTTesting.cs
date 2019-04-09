using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTTesting : MonoBehaviour
{
    public GameObject objectCamera;
    public GameObject cameraMain;
    public Transform refPosition;
    public InteractWithChest script;
    public bool activate = false;
    LTSpline spline;
    public Vector3[] referencePoints;

    private void Start()
    {
        referencePoints = new Vector3[refPosition.childCount];
        for (int i = 0; i < refPosition.childCount; i++)
        {
            referencePoints[i] = refPosition.GetChild(i).transform.position;
        }
        spline = new LTSpline(referencePoints);
    }

    void Update()
    {
        objectCamera.transform.LookAt(transform);
        /*
        if (activate)
        {
            if (Vector3.Distance(objectCamera.transform.position, refPosition.position) > 0.5f)
            {
                LeanTween.move(objectCamera, refPosition.position + Vector3.up, 3);
                objectCamera.transform.LookAt(transform);
            }
            else
            {
                activate = false;
                LeanTween.pauseAll();
                objectCamera.transform.position = refPosition.position;
                script.OpenChest();
            }
        }*/
    }

    public void SetCinematic()
    {
        activate = true;
        objectCamera.SetActive(true);
        cameraMain.SetActive(false);
        LeanTween.moveSpline(objectCamera, spline, 5).setOnComplete(script.CompletedModule);
    }

    public void AnimationCompleted()
    {
        Debug.Log("LA WEA");
        objectCamera.SetActive(false);
        cameraMain.SetActive(true);
        objectCamera.transform.position = referencePoints[0];
    }
}