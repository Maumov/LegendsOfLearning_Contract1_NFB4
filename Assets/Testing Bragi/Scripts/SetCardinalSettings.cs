using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetCardinalSettings : MonoBehaviour
{
    public Color cardinalColor = Color.white;
    private TextMeshProUGUI[] cardinals;

    private void Start()
    {
        cardinals = GetComponentsInChildren<TextMeshProUGUI>();
        for(int i = 0; i < cardinals.Length; i++)
        {
            cardinals[i].color = cardinalColor;
        }
    }
}