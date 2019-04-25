using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnviroment : InteractableObject
{
    public string typeOf;

    public override void Interaction()
    {
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        EnviromentController.instance.DestroyEnviromentSound(typeOf, transform.position);
        // Animation
        //AudioSource source = gameObject.AddComponent<AudioSource>();
        //source.clip =
        Destroy(gameObject);
        yield return null;
    }
}