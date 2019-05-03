using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [Header("Follow Player")]
    public Transform player;
    public Camera miniMapCam;
    public float offset;
    public bool isStatic = false;

    [Header("Cardinal Settings")]
    public GameObject cardinal;
    public Color cardinalColor = Color.white;
    public Transform miniMapRender;
    private TextMeshProUGUI[] cardinals;
    
    private void Start()
    {
        cardinals = cardinal.GetComponentsInChildren<TextMeshProUGUI>();
        for (int i = 0; i < cardinals.Length; i++)
        {
            cardinals[i].color = cardinalColor;
        }

        if (isStatic)
        {
            miniMapRender.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void Update()
    {
        if (!isStatic)
        {
            miniMapRender.rotation = Quaternion.Euler(0f, 0f, -player.localEulerAngles.y);
        }
    }

    private void LateUpdate()
    {
        miniMapCam.transform.position = new Vector3(player.position.x, player.position.y + offset, player.position.z);
    }
}