using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{
    public AudioSource enviroment;
    public AudioSource interactableSource;
    public AudioClip grassSound;
    public AudioClip logSound;

    public static EnviromentController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void DestroyEnviromentSound(string name, Vector3 position)
    {
        transform.position = position;
        if (!interactableSource.isPlaying)
        {
            switch (name)
            {
                case "Grass":
                    interactableSource.clip = grassSound;
                    break;
                case "Log":
                    interactableSource.clip = logSound;
                    break;
            }
            interactableSource.Play();
        }
    }
}