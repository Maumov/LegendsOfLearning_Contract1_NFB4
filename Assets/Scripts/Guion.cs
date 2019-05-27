using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Guion : MonoBehaviour
{
    public MessagesController messageController;
    //Intro
    public Capitulo Intro;
    //Tutorial minimapa
    public Capitulo Minimapa;
    //Tutorial Cofreencontrado
    public Capitulo CofreEncontrado;
    //Tutorial Cofreencontrado
    public Capitulo CofreTerminado;
    //Tutorial puerta
    public Capitulo Puerta;
    public Capitulo PuertaFinal;
    //FeedBackPuerta
    public Capitulo PuertaFeedbackPos;
    public Capitulo PuertaFeedbackNeg;
    //Tutorial modulo1
    public Capitulo Modulo1;
    //Tutorial modulo2
    public Capitulo Modulo2;
    //Tutorial modulo3
    public Capitulo Modulo3;
    //feedback modulo12 pos neg
    public Capitulo FeedbackPosModulo12;
    public Capitulo FeedbackNegModulo12;
    //feedback modulo3 pos neg
    public Capitulo FeedbackPosModulo3;
    public Capitulo FeedbackNegModulo3;
    //Final de juego
    public Capitulo UltimoCofre;
    //Final de juego
    public Capitulo End;
    


    public void StartIntro() {
        StartCoroutine(TutorialStarted(Intro));
    }

    public void StartMinimapa() {
        StartCoroutine(TutorialStarted(Minimapa));
    }

    public void StartPuerta() {
        StartCoroutine(TutorialStarted(Puerta));
    }

    public void StartPuertaFeedBackPos()
    {
        StartCoroutine(TutorialStarted(PuertaFeedbackPos));
    }

    public void StartPuertaFeedBackNeg()
    {
        StartCoroutine(TutorialStarted(PuertaFeedbackNeg));
    }

    public void StartPuertafinal()
    {
        StartCoroutine(TutorialStarted(PuertaFinal));
    }

    public void StartCofre()
    {
        StartCoroutine(TutorialStarted(CofreEncontrado));
    }

    public void StartModulo1() {
        StartCoroutine(TutorialStarted(Modulo1));
    }

    public void StartModulo2() {
        StartCoroutine(TutorialStarted(Modulo2));
    }

    public void StartModulo3() {
        StartCoroutine(TutorialStarted(Modulo3));
    }

    public void StartModulo12FeedbackPos()
    {
        StartCoroutine(TutorialStarted(FeedbackPosModulo12));
    }

    public void StartModulo12FeedbackNeg()
    {
        StartCoroutine(TutorialStarted(FeedbackNegModulo12));
    }

    public void StartModulo3FeedbackPos()
    {
        StartCoroutine(TutorialStarted(FeedbackPosModulo3));
    }

    public void StartModulo3FeedbackNeg()
    {
        StartCoroutine(TutorialStarted(FeedbackNegModulo3));
    }

    public void StartCofreEnd()
    {
        StartCoroutine(TutorialStarted(CofreTerminado));
    }

    public void StartUltimoCofre()
    {
        StartCoroutine(TutorialStarted(UltimoCofre));
    }

    public void StartEnd() {
        StartCoroutine(TutorialStarted(End));
    }

    IEnumerator TutorialStarted(Capitulo cap) {
        messageController.SpawnText(cap.frases);
        //for(int i = 0; i < cap.frases.Count -1; i++) {
        //    messageController.AddText(cap.GetSiguienteFrase());
        //    yield return null;
        //}
        yield return null;
    }


    bool doorCompleted;
    public void DoorTutorial(bool rightAnswer)
    {
        if (doorCompleted == false)
        {
            if (rightAnswer == true)
            {StartPuertaFeedBackPos();
            }
            else if (rightAnswer == false)
            {
                StartPuertaFeedBackNeg();
            }

        }
    }

    bool tutorial1Finished;
    public void Modulo1Tutorial()
    {
        if (tutorial1Finished == false)
        {

        }
    }

    bool tutorial2Finished;
    public void Modulo2Tutorial()
    {
        if (tutorial2Finished == false)
        {

        }
    }

    bool tutorial3Finished;
    public void Modulo3Tutorial()
    {
        if (tutorial3Finished == false)
        {

        }
    }
}
[System.Serializable]
public class Capitulo {
    public List<Frases> frases;
    int currentFrase = 0;

    public Frases GetSiguienteFrase() {
        currentFrase++;
        return frases[currentFrase];
    }
    public Frases GetFrase() {
        return frases[currentFrase];
    }


}
[System.Serializable]
public class Frases {
    public string key;
    public UnityEvent evento;
}
