using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(CameraPanning))]
public class PanningEvent : MonoBehaviour
{
    CameraPanning panning;
    public UnityEvent OnStart;
    public UnityEvent OnComplete;

    private void Start()
    {
        panning = GetComponent<CameraPanning>();
    }

    private void Update()
    {
        if (panning.tweenID != null)
        {
            panning.tweenID.setOnStart(OnStart.Invoke);

            panning.tweenID.setOnComplete(OnComplete.Invoke);
        }
    }
}