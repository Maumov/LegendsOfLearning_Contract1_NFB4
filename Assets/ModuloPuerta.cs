using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuloPuerta : MonoBehaviour
{
    Puerta puerta;
    public GameObject[] gameObjectsToFill;
    public GameObject[] gameObjectsToEmpty;
    public float animDuration = 10f;
    public Text preguntaNumerador, preguntaDenominador;

    void Start() {
        puerta = GetComponentInParent<Puerta>();
        preguntaNumerador.text = puerta.question.numerador.ToString();
        preguntaDenominador.text = puerta.question.denominador.ToString();
        
    }

    public void CheckRespuesta() {
        StartCoroutine(Animate1());
        
        
    }

    IEnumerator Animate1() {
        float j = 0f;
        while(j < puerta.valor) {
            j += (Time.deltaTime / animDuration);
            for(int i = 0; i < gameObjectsToFill.Length; i++) {
                gameObjectsToFill[i].transform.localScale = Vector3.Lerp(new Vector3(0.001f, 1f, 1f), new Vector3(1f, 1f, 1f), j);
            }
            for(int i = 0; i < gameObjectsToEmpty.Length; i++) {
                gameObjectsToEmpty[i].transform.localScale = Vector3.Lerp(new Vector3(1f, 1f, 1f), new Vector3(0f, 0f, 0f), j);
            }
            yield return null;
        }
        yield return null;
        if(puerta.CheckQuestion()) {
            Good();
        } else {
            Bad();
        }
    }

    void Bad() {
        Debug.Log("Bad");
    }

    void Good() {
        Debug.Log("Good");
    }
}
