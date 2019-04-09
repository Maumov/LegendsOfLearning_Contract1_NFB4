using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HideCursor : EditorWindow
{
    [MenuItem("Custom Editor/Cursor/Enable")]
    static void EnableCursor()
    {
        Cursor.visible = true;
    }

    [MenuItem("Custom Editor/Cursor/Disable")]
    static void DisableCursor()
    {
        Cursor.visible = false;
    }

    [MenuItem("Custom Editor/Cursor/Status")]
    static void CheckCursorStatus()
    {
        Debug.Log(Cursor.visible);
    }
}