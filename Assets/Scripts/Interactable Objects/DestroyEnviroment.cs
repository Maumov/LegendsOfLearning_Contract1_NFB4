using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnviroment : InteractableObject
{
    public GameObject sfxPrefab;
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
        ParticleSystem grassPart = Instantiate(EnviromentController.instance.grassParticle, transform.position + (Vector3.up * 1.5f), Quaternion.identity);
        grassPart.gameObject.GetComponent<AudioSource>().clip = EnviromentController.instance.DestroyEnviromentSound();
        grassPart.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        yield return null;
    }
}