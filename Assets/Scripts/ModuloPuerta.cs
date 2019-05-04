using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuloPuerta : MonoBehaviour
{
    public int modulo;
    public Puerta puerta;
    public GameObject[] gameObjectsToFill;
    public GameObject[] gameObjectsToEmpty;
    public float animDuration = 10f;
    public Text preguntaNumerador, preguntaDenominador;
    
    public Image image;

    public Image boton;
    public GameObject tranca;

    void Start() {
        puerta = GetComponentInParent<Puerta>();
       
        
    }

    public void SetUIStart() {
        preguntaNumerador.text = puerta.question.numerador.ToString();
        preguntaDenominador.text = puerta.question.denominador.ToString();
    }

    public void CheckRespuesta() {
        if(modulo == 1) {
            StartCoroutine(Animate1());
        }
        if(modulo == 2) {
            StartCoroutine(Animate2());
        }
        if(modulo == 3) {
            StartCoroutine(Animate3());
        }
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

    IEnumerator Animate2() {
        float j = 0f;
        while(j < puerta.valor) {
            j += (Time.deltaTime / animDuration);
            for(int i = 0; i < gameObjectsToFill.Length; i++) {
                gameObjectsToFill[i].transform.localScale = Vector3.Lerp(new Vector3(1f,1f, 0.001f), new Vector3(1f, 1f, 1f), j);
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

    IEnumerator Animate3() {
        float j = 0f;
        while(j < puerta.valor) {
            j += (Time.deltaTime / animDuration);
            image.fillAmount = j;
            yield return null;
        }
        yield return null;
        if(puerta.CheckQuestion()) {
            Good();
        } else {
            Bad();
        }
    }

    IEnumerator AnimateTranca() {
        float j = 0f;
        while(j < 1f) {
            j += (Time.deltaTime / 1f);
            tranca.transform.Translate(0f, j * Time.deltaTime, 0f);
            yield return null;
        }
        tranca.SetActive(false);
        if(modulo == 1) {
            puerta.m1 = true;
        }
        if(modulo == 2) {
            puerta.m2 = true;
        }
        if(modulo == 3) {
            puerta.m3 = true;
        }
        puerta.OpenGate();
        yield return null;
    }

    


    void Bad() {
        Debug.Log("Bad");
    }

    void Good() {
        StartCoroutine(AnimateTranca());
        boton.color = Color.green;
        Debug.Log("Good");
    }
}
