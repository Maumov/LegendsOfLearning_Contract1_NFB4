using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    public RawImage icon;
    public TextMeshProUGUI horizontal;
    public TextMeshProUGUI vertical;

    public void SetSlot(MapIconPrefab script)
    {
        Texture temp = script.GetComponent<RawImage>().texture;
        if(temp != null)
        {
            icon.texture = temp;
        }
        horizontal.text = script.numerators.x + "/" + script.denimators.x;
        vertical.text = script.numerators.y + "/" + script.denimators.y;
    }
}
