using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Puerta : MonoBehaviour
{

    public float valor = 0f;
    public float step = 0.01f;
    public float minValor = 0f;
    public float maxValor = 10f;
    public UnityEvent giroDerecha, giroIzquierda, boton1, boton2, boton3;
   

    public void GirarIzquierda() {
        valor -= step;
        valor = Mathf.Clamp(valor, minValor, maxValor);
    }

    public void GirarDerecha() {
        valor += step;
        valor = Mathf.Clamp(valor, minValor, maxValor);
    }

    public void Button1() {
        boton1.Invoke();
    }
    public void Button2() {
        boton2.Invoke();
    }
    public void Button3() {
        boton3.Invoke();
    }
}
