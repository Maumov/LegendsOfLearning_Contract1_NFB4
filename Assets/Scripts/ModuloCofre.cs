﻿using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using LoLSDK;
using UnityEngine;

using UnityEngine.UI;

public class ModuloCofre : MonoBehaviour
{
    [Header("Base")]
    Cofre cofre;
    Guion guion;
    AudioSource sonidos;
    public AudioClip wrongSound;
    public AudioClip rightSound;
    public AudioClip wheelSound;
    public int modulo;
    public Question question, question2;
    public GameObject cam;
    public int valor = 0;
    [Header("Modulo 1 y 2")]
    public Text preguntaNumerador1;
    public Text preguntaDenominador1;
    public Text preguntaNumerador2, preguntaDenominador2;
    public Text preguntaDenominador3;
    public GameObject tranca;
    public RectTransform canvasTransform;
    public Image image1;
    public Image image2;
    public Image bigDenominator, smallDenominator;
    public GameObject rotator;
    public Image checkButton;
    [Header("Modulo 3")]
    public GameObject[] top;
    public GameObject[] left;
    public GameObject buttonPrefab;
    public Material activoVertical, noActivoVertical;
    public Material activoHorizontal, noActivoHorizontal;
    public int currentDenominatorX, currentDenominatorY;
    public GameObject panel;
    public List<GameObject> botones;
    bool isBusy;

    private void Start()
    {
        cofre = GetComponentInParent<Cofre>();
        guion = FindObjectOfType<Guion>();
        sonidos = GetComponent<AudioSource>();
        SetQuestion();

    }

    void SetQuestion()
    {
        question.denominador = Random.Range(2, 10);
        question.numerador = Random.Range(1, Mathf.CeilToInt(question.denominador));
        question2.denominador = Random.Range(2, 10);
        question2.numerador = Random.Range(1, Mathf.CeilToInt(question2.denominador));
        SetUIStart();
    }

    public void SetUIStart()
    {

        preguntaNumerador1.text = question.numerador.ToString();
        preguntaDenominador1.text = question.denominador.ToString();
        preguntaNumerador2.text = question2.numerador.ToString();
        preguntaDenominador2.text = question2.denominador.ToString();

        if (modulo != 2)
        {
            preguntaDenominador3.text = (question.denominador * question2.denominador).ToString();
        }

        if (modulo == 0)
        {
            image1.fillAmount = (question2.numerador / question2.denominador);
            float den = (float)(question.denominador * question2.denominador);
            for (int i = 0; i < den + 1; i++)
            {
                Image im = Instantiate(smallDenominator, image2.rectTransform);
                float angle = (i * 360f / den) - 90f;
                float x = Mathf.Cos(-angle * Mathf.Deg2Rad);
                float y = Mathf.Sin(-angle * Mathf.Deg2Rad);
                Vector3 dir = new Vector3(x, y, 0f) * 305f;
                im.rectTransform.localPosition = Vector3.zero + dir;
                im.rectTransform.Rotate(0f, 0f, -angle + 90f);
            }
            for (int i = 0; i < question2.denominador + 1; i++)
            {
                Image im = Instantiate(bigDenominator, image2.rectTransform);
                float angle = (i * 360f / ((float)question2.denominador)) - 90f;
                float x = Mathf.Cos(-angle * Mathf.Deg2Rad);
                float y = Mathf.Sin(-angle * Mathf.Deg2Rad);
                Vector3 dir = new Vector3(x, y, 0f) * 310f;
                im.rectTransform.localPosition = Vector3.zero + dir;
                im.rectTransform.Rotate(0f, 0f, -angle + 90f);
            }
        }

        if (modulo == 1)
        {
            image1.fillAmount = (question2.numerador / question2.denominador) * 0.5f;
            float den = (float)(question.denominador * question2.denominador);
            for (int i = 0; i < den + 1; i++)
            {
                Image im = Instantiate(smallDenominator, image2.rectTransform);
                float angle = (i * 180f / den) - 90f;

                float x = Mathf.Cos(-angle * Mathf.Deg2Rad);
                float y = Mathf.Sin(-angle * Mathf.Deg2Rad);
                Vector3 dir = new Vector3(x, y, 0f) * 390f;
                im.rectTransform.localPosition = Vector3.zero + dir;
                im.rectTransform.Rotate(0f, 0f, -angle + 90f);

            }
            for (int i = 0; i < question2.denominador + 1; i++)
            {
                Image im = Instantiate(bigDenominator, image2.rectTransform);
                float angle = (i * 180f / ((float)question2.denominador)) - 90f;
                float x = Mathf.Cos(-angle * Mathf.Deg2Rad);
                float y = Mathf.Sin(-angle * Mathf.Deg2Rad);
                Vector3 dir = new Vector3(x, y, 0f) * 390f;
                im.rectTransform.localPosition = Vector3.zero + dir;
                im.rectTransform.Rotate(0f, 0f, -angle + 90f);
            }
        }

        if (modulo == 2)
        {
            top[(int)question.denominador - 2].SetActive(true);
            left[(int)question2.denominador - 2].SetActive(true);
            //scala
            for (int i = 0; i < question.denominador; i++)
            {
                top[(int)question.denominador - 2].transform.GetChild(i).gameObject.SetActive(true);
                //                top[(int)question.denominador - 2].transform.GetChild(i).gameObject.transform.localScale *= 0.85f;
                top[(int)question.denominador - 2].transform.GetChild(i).gameObject.GetComponent<Renderer>().material = noActivoHorizontal;
            }
            for (int i = 0; i < (int)question2.denominador; i++)
            {
                left[(int)question2.denominador - 2].transform.GetChild(i).gameObject.SetActive(true);
                //                left[(int)question2.denominador - 2].transform.GetChild(i).gameObject.transform.localScale *= 0.85f;
                left[(int)question2.denominador - 2].transform.GetChild(i).gameObject.GetComponent<Renderer>().material = noActivoVertical;
            }
            //color
            for (int i = 0; i < (int)question.numerador; i++)
            {
                top[(int)question.denominador - 2].transform.GetChild(i).gameObject.SetActive(true);
                top[(int)question.denominador - 2].transform.GetChild(i).gameObject.GetComponent<Renderer>().material = activoHorizontal;
            }
            for (int i = 0; i < (int)question2.numerador; i++)
            {
                left[(int)question2.denominador - 2].transform.GetChild(i).gameObject.SetActive(true);
                left[(int)question2.denominador - 2].transform.GetChild(i).gameObject.GetComponent<Renderer>().material = activoVertical;
            }
            CreateButtons();
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void SetValor(string val)
    {
        if (val == "")
        {
            val = "0";
        }
        if (val == ".")
        {
            val = "0.";
        }
        try {
            valor = int.Parse(val);
        }catch{
            Debug.Log("meh!");
        }
        
    }
    [ContextMenu("Text")]
    public void TestAnswer()
    {
        if (isBusy)
        {
            return;
        }
        isBusy = true;
        if (modulo == 0 || modulo == 1)
        {
            StartCoroutine(AnimateSolution());
        }
        if (modulo == 2)
        {
            if (question.numerador * question2.numerador == numeradorRespuesta() && question.denominador * question2.denominador == botones.Count)
            {
                Good();
            }
            else
            {
                Bad();
            }
        }
    }

    int numeradorRespuesta()
    {
        int c = 0;
        for (int i = 0; i < botones.Count; i++)
        {
            if (botones[i].GetComponent<ModuloBotonTres>().sw)
            {
                c++;
            }
        }
        return c;
    }

    public void AddDenominador1()
    {
        currentDenominatorX++;
        currentDenominatorX = Mathf.Clamp(currentDenominatorX, 2, 10);
        CreateButtons();
        CheckAnswerMod3Top();
    }
    public void AddDenominador2()
    {
        currentDenominatorY++;
        currentDenominatorY = Mathf.Clamp(currentDenominatorY, 2, 10);
        CreateButtons();
        CheckAnswerMod3Left();
    }
    public void TakeoutDenominador1()
    {
        currentDenominatorX--;
        currentDenominatorX = Mathf.Clamp(currentDenominatorX, 2, 10);
        CreateButtons();
        CheckAnswerMod3Top();
    }
    public void TakeoutDenominador2()
    {
        currentDenominatorY--;
        currentDenominatorY = Mathf.Clamp(currentDenominatorY, 2, 10);
        CreateButtons();
        CheckAnswerMod3Left();
    }


    void Bad()
    {
        isBusy = false;
        guion.ModuloTutorialFeedBack(false, modulo);
        sonidos.clip = wrongSound;
        sonidos.Play();
        Debug.Log("Bad");
    }

    void Good()
    {
        GameManager.UpdateProgress();
        guion.ModuloTutorialFeedBack(true, modulo);
        StartCoroutine(AnimateTranca());
        checkButton.color = Color.green;
        sonidos.clip = rightSound;
        sonidos.Play();
        Debug.Log("Good");
    }

    void DestroyAllButtons()
    {
        for (int i = 0; i < botones.Count; i++)
        {
            Destroy(botones[i].gameObject);
        }
        botones = new List<GameObject>();
    }
    [ContextMenu("Test")]
    void CreateButtons()
    {
        DestroyAllButtons();
        for (int i = 0; i < currentDenominatorX; i++)
        {
            for (int j = 0; j < currentDenominatorY; j++)
            {
                GameObject go = (GameObject)Instantiate(buttonPrefab, panel.transform);
                RectTransform rT = go.GetComponent<RectTransform>();
                float height = panel.GetComponent<RectTransform>().rect.height / currentDenominatorY;
                float width = panel.GetComponent<RectTransform>().rect.width / currentDenominatorX;
                float basePositionX = -(panel.GetComponent<RectTransform>().rect.width * .5f) + (width * .5f);
                float basePositionY = -(panel.GetComponent<RectTransform>().rect.height * .5f) + (height * .5f);
                rT.anchoredPosition = new Vector2(basePositionX + ((float)i) * width, basePositionY + ((float)j) * height);
                //rT.sizeDelta = new Vector2(width, height);
                rT.sizeDelta = new Vector2(width * 0.85f, height * 0.85f);
                go.SetActive(true);
                //( basePositionX + ((float)i) * width, basePositionY + ((float)j) * height, width, height);
                botones.Add(go);
            }
        }
    }

    IEnumerator AnimateSolution()
    {
        rotator.transform.localRotation = Quaternion.identity;
        float animDuration = 2f;
        float i = 0f;
        float den = (float)(question.denominador * question2.denominador);

        sonidos.clip = wheelSound;
        sonidos.Play();
        image2.fillAmount = 0f;
        while (i <= animDuration)
        {
            i += Time.deltaTime;
            if (modulo == 0)
            {
                rotator.transform.RotateAround(rotator.transform.position, rotator.transform.right, ((-valor / den) * 360f) * (Time.deltaTime / animDuration));
                Debug.Log(((valor / den) * (Time.deltaTime / animDuration)));
                //image2.fillAmount = Mathf.Abs(Vector3.SignedAngle(rotator.transform.forward,Vector3.up, rotator.transform.up) / 360f);
                image2.fillAmount += ((valor / den)  * (Time.deltaTime / animDuration));
            }
            else
            {
                rotator.transform.RotateAround(rotator.transform.position, rotator.transform.right, ((-valor / den) * 180f) * (Time.deltaTime / animDuration));
                //image2.fillAmount = Vector3.SignedAngle(rotator.transform.forward, Vector3.up, rotator.transform.up) / 360f;
                //image2.fillAmount = Vector3.Angle(rotator.transform.forward, Vector3.up) / 360f;
                image2.fillAmount += (((valor / den) * (Time.deltaTime / animDuration)) * 0.5f);
            }
            yield return null;
        }
        //Debug.Log(Vector3.Angle(rotator.transform.forward, Vector3.up));
        //Vector3.an
        //Debug.Log(Vector3.SignedAngle(rotator.transform.forward, Vector3.up, rotator.transform.up));
        if (valor == question.numerador * question2.numerador)
        {
            Good();
        }
        else
        {
            Bad();
        }
        yield return null;
    }

    IEnumerator AnimateTranca()
    {
        float j = 0f;
        while (j < 1f)
        {
            j += (Time.deltaTime / 1f);
            tranca.transform.Translate(0f, j * Time.deltaTime, 0f);
            yield return null;
        }
        tranca.SetActive(false);
        EndInteraction();
    }

    public void StartInteraction()
    {
        canvasTransform.gameObject.SetActive(true);
        cam.gameObject.SetActive(true);
    }

    public void EndInteraction()
    {
        canvasTransform.gameObject.SetActive(false);
        GetComponentInParent<Cofre>().ModuloFinished();
        cam.gameObject.SetActive(false);
    }

    public void CheckAnswerMod3Left()
    {
        if (!guion.tutorialModulo3FinishedFeedback)
        {
            if (currentDenominatorY == question2.denominador)
            {
                guion.textDisplay.SetActive(true);
            }
        }
    }

    public void CheckAnswerMod3Top()
    {
        if (!guion.tutorialModulo3FinishedFeedback)
        {
            if (currentDenominatorX == question.denominador)
            {
                guion.textDisplay.SetActive(true);
            }
        }
    }
}