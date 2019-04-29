using System.Collections;
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

    private void Start() {
        SetQuestion();
    }

    void SetQuestion() {
        int a = Random.Range(0, posibleQuestions.Length);
        question = posibleQuestions[a];
    }



    public void UpdateRespuestaUI(string v) {
       
        valor = float.Parse(textRespuesta.text.Replace("." , ","));
    }
    

    public bool CheckQuestion() {
        if(valor == question.cociente) {
            return true;
        }
        return false;
    }
}

[System.Serializable]
public class Question {
    public float numerador;
    public float denominador;
    public float cociente;

    
}