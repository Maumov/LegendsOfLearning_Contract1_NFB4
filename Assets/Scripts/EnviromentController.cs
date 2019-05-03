using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{
    public AudioSource enviroment;
    [Header("Sounds")]
    public AudioClip grassSound;
    public AudioClip logSound;

    public static EnviromentController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public AudioClip DestroyEnviromentSound(string name)
    {
        switch (name)
        {
            case "Grass":
                return grassSound;
            case "Log":
                return logSound;
            default:
                return grassSound;
        }
    }
}