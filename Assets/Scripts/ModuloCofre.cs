using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ModuloCofre : MonoBehaviour
{
    Cofre cofre;
    public Question question;
    public float valor = 0f;
    public float step = 0.01f;
    public float minValor = 0f;
    public float maxValor = 10f;

    public Text preguntaNumerador, preguntaDenominador;

    private void Start() {
        cofre = GetComponentInParent<Cofre>();
        SetQuestion();
    }

    void SetQuestion() {
        int a = Random.Range(0, cofre.posibleQuestions.Length);
        question = cofre.posibleQuestions[a];
        ModuloPuerta[] modulos = GetComponentsInChildren<ModuloPuerta>();
        foreach(ModuloPuerta mp in modulos) {
            mp.SetUIStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
