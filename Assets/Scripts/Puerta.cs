using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using LoLSDK;

public class Puerta : MonoBehaviour
{
    public Question[] posibleQuestions;
    public Question question;
    public float valor = 0f;
    public float step = 0.01f;
    public float minValor = 0f;
    public float maxValor = 10f;
    public UnityEvent giroDerecha, giroIzquierda, boton1, boton2, boton3;
    AudioSource sonido;

    public InputField textRespuesta;
    public float animDuration = 10f;
    public bool m1, m2, m3;
    public GameObject virtualCamera;
    public GameObject placeHolder;
    public GameObject canvasDoor;

    public UnityEvent InteractionFinished;
    public GameObject fondoNoText;

    private void Start() {
        sonido = GetComponent<AudioSource>();
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
            GameManager.UpdateProgress();
        }
    }

    IEnumerator AnimatePuerta() {
        virtualCamera.SetActive(false);
        virtualCamera.GetComponent<Camera>().enabled = false;
        InteractionFinished.Invoke();
        GetComponent<InteractableObject>().InteractionEnd();
        float j = 0f;
        canvasDoor.SetActive(false);
        sonido.Play();
        while(j < animDuration) {
            j += (Time.deltaTime);
            transform.Translate(0f, -5f * Time.deltaTime, 0f);
            placeHolder.transform.Translate(-5f * Time.deltaTime, 0f, 0f);
            yield return null;
        }
        gameObject.SetActive(false);
        placeHolder.SetActive(false);
        yield return null;
    }


    public void UpdateRespuestaUI(string v) {

        Debug.Log(v);
        if(v == null) {
            v = "0";
        }
        if(v == "") {
            v = "0";
        }
        if(v == ".") {
            v = "0.";
        }
        try {
            valor = float.Parse(v);
            if(valor >= 1f) {
                valor *= 0.1f;
            }
            
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
        virtualCamera.GetComponent<Camera>().orthographic = true;
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