using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    public AudioSource input;
    public AudioSource changeValueButton;
    public AudioSource buttonClick;
    public AudioSource wheel;
    public AudioSource discovery;

    public void PlaySound(UISFXType clip)
    {
        switch (clip)
        {
            case UISFXType.Input:
                input.Play();
                break;
            case UISFXType.ChangeValue:
                changeValueButton.Play();
                break;
            case UISFXType.Click:
                buttonClick.Play();
                break;
            case UISFXType.Wheel:
                wheel.Play();
                break;
            case UISFXType.Discovery:
                discovery.Play();
                break;
        }
    }
}

public enum UISFXType { Input, ChangeValue, Click, Wheel, Discovery}