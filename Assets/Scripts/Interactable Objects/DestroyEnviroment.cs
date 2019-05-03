using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnviroment : InteractableObject
{
    public string type;

    public override void Interaction()
    {
        if (!interacted)
        {
            interacted = true;
            StartCoroutine(DestroyObject());
        }
    }

    IEnumerator DestroyObject()
    {
        // Animation
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = EnviromentController.instance.DestroyEnviromentSound(type);
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        Destroy(gameObject);
        yield return null;
    }
}