using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DestroyEnviroment : InteractableObject
{
    public override void Interaction()
    {
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        AudioSource source = GetComponent<AudioSource>();
        if (source.clip != null)
        {
            source.Play();
            yield return new WaitForSeconds(source.clip.length);
        }
        // Animation

        Destroy(gameObject);
    }
}