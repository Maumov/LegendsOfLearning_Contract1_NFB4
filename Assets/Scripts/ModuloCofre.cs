using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ModuloCofre : MonoBehaviour {
    Cofre cofre;
    public int modulo;
    public Question question, question2;

    public int valor = 0;

    public Text preguntaNumerador1, preguntaDenominador1;
    public Text preguntaNumerador2, preguntaDenominador2;
    public Text preguntaDenominador3;
    public GameObject tranca;
    public RectTransform canvasTransform;
    public Image image1;
    public Image bigDenominator, smallDenominator;
    private void Start() {
        cofre = GetComponentInParent<Cofre>();
        SetQuestion();
    }

    void SetQuestion() {
        question.denominador = Random.Range(2, 10);
        question.numerador = Random.Range(1, Mathf.CeilToInt(question.denominador));
        question2.denominador = Random.Range(2, 10);
        question2.numerador = Random.Range(1, Mathf.CeilToInt(question2.denominador));

        if(modulo == 0 || modulo == 1) {
            SetUIStart();
        }
    }
    public void SetUIStart() {
        preguntaNumerador1.text = question.numerador.ToString();
        preguntaDenominador1.text = question.denominador.ToString();
        preguntaNumerador2.text = question2.numerador.ToString();
        preguntaDenominador2.text = question2.denominador.ToString();
        preguntaDenominador3.text = (question.denominador * question2.denominador).ToString();
        if(modulo == 0) {
            image1.fillAmount = (question2.numerador / question2.denominador);
            float den = (float)(question.denominador * question2.denominador);
            for(int i = 0; i < den + 1; i++) {
                Image im = Instantiate(smallDenominator, image1.rectTransform);
                float angle = (i * 360f / den) - 90f;
                float x = Mathf.Cos(-angle * Mathf.Deg2Rad);
                float y = Mathf.Sin(-angle * Mathf.Deg2Rad);
                Vector3 dir = new Vector3(x, y, 0f) * 280f;
                im.rectTransform.localPosition = Vector3.zero + dir;
            }
            for(int i = 0; i < question2.denominador + 1; i++) {
                Image im = Instantiate(bigDenominator, image1.rectTransform);
                float angle = (i * 360f / ((float)question2.denominador)) - 90f;
                float x = Mathf.Cos(-angle * Mathf.Deg2Rad);
                float y = Mathf.Sin(-angle * Mathf.Deg2Rad);
                Vector3 dir = new Vector3(x, y, 0f) * 280f;
                im.rectTransform.localPosition = Vector3.zero + dir;
            }

            
        }
        if(modulo == 1) {
            image1.fillAmount = (question2.numerador / question2.denominador) * 0.5f;
            float den = (float)(question.denominador * question2.denominador);
            for(int i = 0; i < den + 1; i++) {
                Image im = Instantiate(smallDenominator, image1.rectTransform);
                float angle = (i * 180f / den) - 90f;
                float x = Mathf.Cos(-angle * Mathf.Deg2Rad);
                float y = Mathf.Sin(-angle * Mathf.Deg2Rad);
                Vector3 dir = new Vector3(x, y, 0f) * 330f;
                im.rectTransform.localPosition = Vector3.zero + dir;
            }
            for(int i = 0; i < question2.denominador + 1; i++) {
                Image im = Instantiate(bigDenominator, image1.rectTransform);
                float angle = (i * 180f / ((float)question2.denominador)) - 90f;
                float x = Mathf.Cos(-angle * Mathf.Deg2Rad);
                float y = Mathf.Sin(-angle * Mathf.Deg2Rad);
                Vector3 dir = new Vector3(x, y, 0f) * 330f;
                im.rectTransform.localPosition = Vector3.zero + dir;
            }

           
        }
        
        

    }
    // Update is called once per frame
    void Update() {

    }
    public void SetValor(string val) {
        valor = int.Parse(val);
    }

    public void TestAnswer() {
        if(valor == question.numerador * question2.numerador) {
            Good();
        } else {
            Bad();
        }
    }

    void Bad() {
        Debug.Log("Bad");
    }

    void Good() {
        StartCoroutine(AnimateTranca());
        //boton.color = Color.green;
        Debug.Log("Good");
    }

    IEnumerator AnimateTranca() {
        float j = 0f;
        while(j < 1f) {
            j += (Time.deltaTime / 1f);
            tranca.transform.Translate(0f, j * Time.deltaTime, 0f);
            yield return null;
        }
        tranca.SetActive(false);

    }
}
