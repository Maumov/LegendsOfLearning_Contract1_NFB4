using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Text gemsCounter;
    internal int gems;
    public GameObject finalPlaceHolder;
    public delegate void GemCounter();
    public static GemCounter counter;
    public GameObject GameOverCanvas;
    public GameObject treasure;
    public ObjectPanning shipPanning;
    public GameObject canvasPointer;

    public MapManager mapManager;
    public Guion guion;
    public TextController textController;
    public CameraMovement cameraMovement;
    public PlayerMovement playerMovement;
    public GameObject multiCanvas;
    public GameObject cameraPivot;
    public GameObject miniMapCanvas;
    public GameObject pointerCanvas;
    public GameObject keyCanvas;
    public InteractableObject interactable;

    private void Start()
    {
        CursorStatus(false);
        counter += UpdateGemsCounter;
    }

    public void UpdateGemsCounter()
    {
        if (gems == 1)
        {
            FindObjectOfType<Guion>().StartCofreEnd();
        }
        if (gems <= 5)
        {
            gems++;
            gemsCounter.text = gems.ToString() + "/4";
        }
        if(gems == 4)
        {
            finalPlaceHolder.SetActive(false);
            FindObjectOfType<Guion>().StartUltimoCofre();
        }
    }

    public static void StaticSetCursorStatus(bool status)
    {
        Cursor.visible = status;
    }

    public void CursorStatus(bool status)
    {
        Cursor.visible = status;
        canvasPointer.SetActive(!status);
    }

    public void LoadCanvas()
    {
        Instantiate(GameOverCanvas);
    }

    public void MapShow() {
        playerMovement.enabled = false;
    }
    
    public void MapHide() {
        playerMovement.enabled = true;
        mapManager.SetMapStatus(true);
    }

    public void GameStart() {
        multiCanvas.SetActive(false);
        mapManager.SetMapStatus(false);
        playerMovement.gameObject.SetActive(false);
        cameraPivot.SetActive(false);
    }

    public void GameStartFinish() {
        playerMovement.gameObject.SetActive(true);
        cameraPivot.SetActive(true);
        multiCanvas.SetActive(true);
        mapManager.SetMapStatus(true);
        guion.StartIntro();
    }

    public void TutorialStart() {
        playerMovement.enabled = false;
        mapManager.SetMapStatus(false);
    }

    public void TutorialFinish() {
        if(interactable != null) {
            if(!interactable.isFocus) {
                playerMovement.enabled = true;
                mapManager.SetMapStatus(true);
            }
        } else {
            mapManager.SetMapStatus(true);
            if(!mapManager.isMapOpen) {
                playerMovement.enabled = true;   
            }
        }
    }

    public void InteractionFinish() {
        cameraPivot.SetActive(true);
        playerMovement.gameObject.SetActive(true);
        mapManager.SetMapStatus(true);
    }

    public void PuertaStart() {
        playerMovement.gameObject.SetActive(false);
        miniMapCanvas.SetActive(false);
        pointerCanvas.SetActive(false);
        keyCanvas.SetActive(false);
        mapManager.SetMapStatus(false);
    }

    public void PuertaFinish() {
        playerMovement.gameObject.SetActive(true);
        cameraPivot.SetActive(true);
        mapManager.SetMapStatus(true);
        miniMapCanvas.SetActive(true);
        pointerCanvas.SetActive(true);
        keyCanvas.SetActive(true);
    }
    public void CofreStart() {
        playerMovement.gameObject.SetActive(false);
    }

    public void CofreFinish() {
        playerMovement.gameObject.SetActive(true);
    }

}