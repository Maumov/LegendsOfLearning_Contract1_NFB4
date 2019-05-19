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

    int currentModulo = 0;
    // Start is called before the first frame update
    void Start()
    {
        modulos = GetComponentsInChildren<ModuloCofre>();
        animaciones = GetComponent<AnimacionesDeCofre>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractionStart() {
        modulos[currentModulo].StartInteraction();
    }

    public void ModuloFinished() {
        currentModulo++;
        NextModulo();
    }

    void NextModulo() {
        if(currentModulo >= modulos.Length) {
            InteractionFinished();
        } else {
            modulos[currentModulo].StartInteraction();
        }
    }

    void InteractionFinished() {
        endInteraction.Invoke();
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
}
