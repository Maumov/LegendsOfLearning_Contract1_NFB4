using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{
    public AudioSource enviroment;
    [Header("Sounds")]
    public AudioClip grassSound;
    public ParticleSystem grassParticle;

    public static EnviromentController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public AudioClip DestroyEnviromentSound()
    {
        return grassSound;
    }
}