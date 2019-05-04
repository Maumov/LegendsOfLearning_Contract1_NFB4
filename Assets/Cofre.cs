using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour {

    public Question[] posibleQuestions;

    public float animDuration = 10f;
    public bool m1, m2, m3;
    // Start is called before the first frame update
    void Start()
    {
        posibleQuestions = FindObjectOfType<Puerta>().posibleQuestions;
    }

    // Update is called once per frame
    void Update()
    {
        
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
