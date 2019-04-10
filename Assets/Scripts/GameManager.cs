using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static List<GameObject> keys;
    private static bool inputStatus = true;

    private void Awake()
    {
        //Cursor.visible = false;
    }

    public void SetInputStatus(bool status)
    {
        inputStatus = status;
    }

    public bool GetInputStatus()
    {
        return inputStatus;
    }

    public static bool AddKey(GameObject key)
    {
        if (keys.Contains(key))
        {
            return false;
        }
        else
        {
            keys.Add(key);
            return true;
        }
    }

    public static int GetKey(string name)
    {
        int index = -1;

        for(int i=0; i < keys.Count; i++)
        {
            if(keys[i].name == name)
            {
                index = i;
            }
        }

        if(index == -1)
        {
            Debug.Log("Not found");
        }
        return index;
    }

    public static string GetKey(int index)
    {
        if (index <= keys.Count)
        {
            return (keys[index].name);
        }
        else
            return null;
    }
}