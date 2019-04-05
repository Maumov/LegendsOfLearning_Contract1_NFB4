using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapRotate : MonoBehaviour
{
    public Transform player;
    public bool isStatic = false;

    private void Update()
    {
        if (!isStatic)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -player.localEulerAngles.y);
        }
    }
}