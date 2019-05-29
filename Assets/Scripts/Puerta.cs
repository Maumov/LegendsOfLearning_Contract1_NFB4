using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Puerta : MonoBehaviour
{
    public AudioSource closedDoor;
    public Question[] posibleQuestions;
    public Question question;
    public float valor = 0f;
    public float step = 0.01f;
    public float minValor = 0f;
    public float maxValor = 10f;
    public UnityEvent giroDerecha, giroIzquierda, boton1, boton2, boton3;

    public InputField textRespuesta;
    public float animDuration = 10f;
    public bool m1, m2, m3;
    public GameObject virtualCamera;
    public GameObject placeHolder;
    public GameObject canvasDoor;

    public UnityEvent InteractionFinished;
    public GameObject fondoNoText;

    private void Start() {
        SetQuestion();
    }
    

    void SetQuestion() {
        int a = Random.Range(0, posibleQuestions.Length);
        question = posibleQuestions[a];
        ModuloPuerta[] modulos = GetComponentsInChildren<ModuloPuerta>();
        foreach(ModuloPuerta mp in modulos) {
            mp.SetUIStart();
        }
    }


    public void OpenGate() {
        if(m1 == true && m2 == true && m3 == true) {
            StartCoroutine(AnimatePuerta());
            FindObjectOfType<Guion>().DoorEndTutorial();
        }
    }

    IEnumerator AnimatePuerta() {
        closedDoor.Play();
        virtualCamera.SetActive(false);
        virtualCamera.GetComponent<Camera>().enabled = false;
        InteractionFinished.Invoke();
        GetComponent<InteractableObject>().InteractionEnd();
        float j = 0f;
        canvasDoor.SetActive(false);
        while(j < animDuration) {
            j += (Time.deltaTime);
            transform.Translate(0f, -1f * Time.deltaTime, 0f);
            placeHolder.transform.Translate(-1f * Time.deltaTime, 0f, 0f);
            yield return null;
        }
        gameObject.SetActive(false);
        placeHolder.SetActive(false);
        yield return null;
    }


    public void UpdateRespuestaUI(string v) {

        Debug.Log(v);
        if(v == null) {
            v = "";
        }
        if(v == "") {
            v = "0";
        }
        if(v == ".") {
            v = "0.";
        }
        try {
            valor = float.Parse(textRespuesta.text.Replace(".", ","));
        } catch {
            Debug.Log("meh!");
        }
    }
    

    public bool CheckQuestion() {
        if(valor == question.cociente) {
            return true;
        }
        return false;
    }
    public void StartInteraction() {
        ////GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
        //virtualCamera.GetComponent<Camera>().enabled = true;
        //virtualCamera.SetActive(true);
        //virtualCamera.GetComponent<Camera>().orthographic = true;
        virtualCamera.SetActive(true);
        canvasDoor.SetActive(true);
    }

    public void TutorialPuertaFeedback(bool rightAnswer) {
        FindObjectOfType<Guion>().DoorTutorialFeedback(rightAnswer);
    }
}

[System.Serializable]
public class Question {
    public float numerador;
    public float denominador;
    public float cociente;
}