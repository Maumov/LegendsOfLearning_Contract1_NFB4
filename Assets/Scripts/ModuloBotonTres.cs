using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuloBotonTres : MonoBehaviour
{
    Image image;
    public Color activo, noActivo;
    public bool sw = false;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = noActivo;
    }

    public void ButtonPressed() {
        if(sw) {
            image.color = noActivo;
        } else {
            image.color = activo;
        }
        sw = !sw;
    }

}
