using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cofre : MonoBehaviour {

    public Question[] posibleQuestions;

    public float animDuration = 10f;
    public bool m1, m2, m3;

    public ModuloCofre[] modulos;
    AnimacionesDeCofre animaciones;
    public UnityEvent endInteraction;
    GameObject mainCamera;
    internal int currentModulo = 0;
    // Start is called before the first frame update
    void Start()
    {
        modulos = GetComponentsInChildren<ModuloCofre>();
        animaciones = GetComponent<AnimacionesDeCofre>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void InteractionStart() {
        modulos[currentModulo].StartInteraction();
        mainCamera.SetActive(false);
        TutorialModulo();
    }

    public void ModuloFinished() {
        currentModulo++;
        NextModulo();
        //Camera.main.orthographic = false;
    }

    void NextModulo() {
        if(currentModulo >= modulos.Length) {
            InteractionFinished();
        } else {
            modulos[currentModulo].StartInteraction();
            TutorialModulo();
        }
    }

    void InteractionFinished() {
        if(GameManager.counter != null)
        {
            GameManager.counter();
        }
        animaciones.AnimacionTapa();
        endInteraction.Invoke();
        mainCamera.SetActive(true);
    }


    public void OpenGate() {
        if(m1 == true && m2 == true && m3 == true) {
            StartCoroutine(AnimateCofre());
        }
    }

    IEnumerator AnimateCofre() {
        float j = 0f;
        while(j < animDuration) {
            j += (Time.deltaTime);
            transform.Translate(0f, -1f * Time.deltaTime, 0f);
            yield return null;
        }
        gameObject.SetActive(false);
        yield return null;
    }

    public void TutorialModulo()
    {
        if (currentModulo == 0)
        {
            FindObjectOfType<Guion>().StartModulo1();
        }
        else if (currentModulo == 1)
        {
            FindObjectOfType<Guion>().StartModulo2();
        }
        else if (currentModulo == 2)
        {
            FindObjectOfType<Guion>().StartModulo3();
        }
    }

}
