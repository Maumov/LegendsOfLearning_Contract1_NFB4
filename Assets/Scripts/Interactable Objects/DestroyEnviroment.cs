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
        
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
        yield return null;
    }
}