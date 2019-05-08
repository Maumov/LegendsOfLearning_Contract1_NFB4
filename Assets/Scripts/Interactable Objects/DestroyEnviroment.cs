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
        ParticleSystem grassPart = Instantiate(EnviromentController.instance.grassParticle, transform);
        yield return new WaitForSeconds(grassPart.main.duration/4);
        Destroy(gameObject);
        yield return null;
    }
}