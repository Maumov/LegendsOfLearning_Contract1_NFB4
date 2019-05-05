using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PanningEvent : MonoBehaviour
{
    LTDescr panning;
    public Panning type;
    public UnityEvent OnStart;
    public UnityEvent OnUpdate;
    public UnityEvent OnComplete;

    private void Start()
    {
        if (type == Panning.Camera)
        {
            panning = GetComponent<CameraPanning>().tweenID;
        }
        if (type == Panning.Object)
        {
            panning = GetComponent<ObjectPanning>().tweenID;
        }
    }

    private void Update()
    {
        if (panning != null)
        {
            panning.setOnStart(OnStart.Invoke);
            panning.setOnUpdate(OnUpdate.Invoke);
            panning.setOnComplete(OnComplete.Invoke);

            panning = null;
        }
    }
}

public enum Panning { Camera, Object}