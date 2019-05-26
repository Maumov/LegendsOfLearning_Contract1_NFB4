using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Ortographic : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    public bool isOrthographic;
    public float OrthoSize;

    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        if(cam == null)
        {
            cam = GetComponent<ModuloCofre>().cam;
        }

        if(isOrthographic && cam != null)
        {
            SetOrthographic(true, 0.1f);
        }
    }

    public void SetOrthographic(bool status, float size)
    {
        cam.m_Lens.Orthographic = status;
        cam.m_Lens.OrthographicSize = size;
    }
}