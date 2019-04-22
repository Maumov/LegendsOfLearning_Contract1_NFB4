using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SetFraction : MonoBehaviour
{
    public TextMeshProUGUI numerator;
    public TextMeshProUGUI demoninator;
    RectTransform rectT;

    public void SetPosition(float PosX, float PosY)
    {
        RectTransform rectT = GetComponent<RectTransform>();
        rectT.anchoredPosition = new Vector2(PosX, PosY);
    }

    public void SetNumerator(int number)
    {
      numerator.text = number.ToString();
    }

    public void SetDenominator(int number)
    {
        demoninator.text = number.ToString();
    }
}