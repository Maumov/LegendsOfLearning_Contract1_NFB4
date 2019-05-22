using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesDeCofre : MonoBehaviour
{
    public Animator trancaA, trancaB, trancaC, tapa;
    public GameObject reward;

    public void ActivateAnimation(cerrojo objetoAnimar)
    {
        switch (objetoAnimar)
        {
            case cerrojo.trancaA:
                trancaA.SetTrigger("Open");
                break;
            case cerrojo.trancaB:
                trancaB.SetTrigger("Open");
                break;
            case cerrojo.trancaC:
                trancaC.SetTrigger("Open");
                break;
            case cerrojo.tapa:
                tapa.SetTrigger("Open");
                StartCoroutine(InstanciarRewards());
                break;
        }
    }

    IEnumerator InstanciarRewards()
    {

        yield return new WaitForSeconds(1.5f);
        reward.SetActive(true);
        yield return null;
    }
}

public enum cerrojo { trancaA, trancaB, trancaC, tapa}