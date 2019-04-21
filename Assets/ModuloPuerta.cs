using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuloPuerta : MonoBehaviour
{

    Puerta puerta;

    void Start() {
        puerta = GetComponentInParent<Puerta>();

    }

    public void CheckRespuesta() {

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
