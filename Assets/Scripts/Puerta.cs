﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Puerta : MonoBehaviour
{
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
            FindObjectOfType<Guion>().StartPuertafinal();
        }
    }

    IEnumerator AnimatePuerta() {
        virtualCamera.SetActive(false);
        InteractionFinished.Invoke();
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
        if(v == "") {
            v = "0";
        }
        if(v == ".") {
            v = "0.";
        }
        valor = float.Parse(textRespuesta.text.Replace("." , ","));
    }
    

    public bool CheckQuestion() {
        if(valor == question.cociente) {
            return true;
        }
        return false;
    }
    public void StartInteraction() {
        virtualCamera.SetActive(true);
    }
    
    public TextController textDisplayCanvas;
    public void Tutorial(bool rightAnswer)
    {
      textDisplayCanvas.DoorTutorial(rightAnswer);
    }
}

[System.Serializable]
public class Question {
    public float numerador;
    public float denominador;
    public float cociente;
}
    public TextController textDisplayCanvas;
    public void Tutorial(bool rightAnswer)
    {
      textDisplayCanvas.DoorTutorial(rightAnswer);
    public void Tutorial(bool rightAnswer)
    {
      FindObjectOfType<Guion>().DoorTutorial(rightAnswer);