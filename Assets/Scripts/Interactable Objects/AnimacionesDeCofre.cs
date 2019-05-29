using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class AnimacionesDeCofre : MonoBehaviour
{
    public Animator tapa;
    public GameObject reward;
    public PlayableDirector director;
    AudioSource gemSound;

    private void Start()
    {
        gemSound = GetComponent<AudioSource>();
    }

    public void AnimacionTapa()
    {
        tapa.SetTrigger("Open");
        director.Play();
        StartCoroutine(InstanciarRewards());
    }

    IEnumerator InstanciarRewards()
    {

        yield return new WaitForSeconds(1.5f);
        gemSound.Play();
        reward.SetActive(true);
        yield return null;
    }
}