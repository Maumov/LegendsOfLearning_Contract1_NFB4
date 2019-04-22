using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Puerta : MonoBehaviour
{
    public Question question;
    public float valor = 0f;
    public float step = 0.01f;
    public float minValor = 0f;
    public float maxValor = 10f;
    public UnityEvent giroDerecha, giroIzquierda, boton1, boton2, boton3;

    private void Start() {
        SetQuestion();
    }

    void SetQuestion() {
        question.numerador = 7f;
        question.denominador = 4f;
        question.cociente = question.numerador / question.denominador;
    }

    public void GirarIzquierda() {
        valor -= step;
        valor = Mathf.Clamp(valor, minValor, maxValor);
    }

    public void GirarDerecha() {
        valor += step;
        valor = Mathf.Clamp(valor, minValor, maxValor);
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