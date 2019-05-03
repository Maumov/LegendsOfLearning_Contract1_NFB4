using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Library : MonoBehaviour
{
    public List<TextList> lists = new List<TextList>();

    [HideInInspector] public string filename { get; private set; } = "gameContent.json"; 
    string path;
    InGameData data = new InGameData();

    public static Library instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        GetDataPath();
    }

    [ContextMenu("Create Json")]
    public void CreateJson()
    {
        GetDataPath();
        data.lists = lists;
        string textList = JsonUtility.ToJson(data, true);
        System.IO.File.WriteAllText(path, textList);
    }

    [ContextMenu("Load Json")]
    public void LoadJson()
    {
        GetDataPath();
        string basicData = System.IO.File.ReadAllText(path);
        data = JsonUtility.FromJson<InGameData>(basicData);
        lists = data.lists;
    }

    [ContextMenu("Clear Json")]

    public void ClearJson()
    {
        GetDataPath();
        data.lists.Clear();
        string basicData = JsonUtility.ToJson(data, true);
        System.IO.File.WriteAllText(path, basicData);
    }

    public List<string> GetText(string name)
    {
        for (int i = 0; i < lists.Count; i++)
        {
            if(lists[i].name == name)
            {
                return lists[i].list;
            }
        }

        return new List<string>();
    }
    
    public string GetDataPath()
    {
        path = Application.dataPath + "/" + filename;
        return path;
    }
}

[System.Serializable]
public class TextList
{
    public string name;
    public List<string> list = new List<string>();
}

[System.Serializable]
public class InGameData
{
    public List<TextList> lists = new List<TextList>();
}