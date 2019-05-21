using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class ColisionConTesoro : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;
    public GameManager manager;
    public CineMachineMovement cameraMovement;
    public PlayableDirector director;
    public PlayableDirector ending;
    public GameObject parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player"))
        {
            parent.SetActive(true);
            player.SetActive(false);
            mainCamera.SetActive(false);
            cameraMovement.StartPanning();
            director.Play();
            StartCoroutine(endingTrigger());
        }
    }

    IEnumerator endingTrigger()
    {
        yield return new WaitForSeconds((float)director.duration);
        manager.GameOver();
        parent.SetActive(false);
        yield break;
    }
}
