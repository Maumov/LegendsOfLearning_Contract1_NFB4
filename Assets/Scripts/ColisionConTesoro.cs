using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class ColisionConTesoro : MonoBehaviour
{
    public GameObject player;
    public GameObject UI;
    public PlayableDirector ending;
    public CineMachineMovement movement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player"))
        {
            MapManager.instance.SetMapStatus(false);
            CameraMovement.StaticSetInputs(false);
            UI.SetActive(false);
            player.SetActive(false);
            ending.gameObject.SetActive(true);
            ending.Play();
            movement.StartPanning();
        }
    }
}