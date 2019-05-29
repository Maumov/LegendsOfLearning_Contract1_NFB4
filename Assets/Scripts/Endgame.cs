using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;
public class Endgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LOLSDK.Instance.CompleteGame();
    }

}
