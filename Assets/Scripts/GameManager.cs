using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        CursorStatus(false);
    }

    public static void StaticSetCursorStatus(bool status)
    {
        Cursor.visible = status;
    }

    public void CursorStatus(bool status)
    {
        Cursor.visible = status;
    }
}