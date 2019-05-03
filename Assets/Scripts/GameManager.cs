﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        DisableCursor();
    }

    public static void SetCursorStatus(bool status)
    {
        if (status)
        {
            EnableCursor();
        }
        else
        {
            Cursor.visible = false;
        }
    }


    [MenuItem("Tools/Cursor/Enable")]
    public static void EnableCursor()
    {
        Cursor.visible = true;
    }

    [MenuItem("Tools/Cursor/Disable")]
    public static void DisableCursor()
    {
        Cursor.visible = false;
    }
}
