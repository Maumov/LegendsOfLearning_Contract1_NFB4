using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DoorsManager
{
    public static List<Door> doors = new List<Door>();
    public static List<Door> completed = new List<Door>();

    public static bool SpawnDoor(int id)
    {
        bool exist = false;
        for (int i = 0; i < doors.Count; i++)
        {
            if (id == doors[i].id)
            {
//                doors[i].placeholder.SetActive(false);
                doors[i].door.SetActive(true);
                //MapManager.instance.SetIcon(doors[i].xNum, doors[i].xDem, doors[i].yNum, doors[i].yDem, "Treasure", doors[i].id);
                exist = true;
            }
        }

        return exist;
    }

    public static bool SpawnDoor(GameObject door)
    {
        bool exist = false;
        for (int i = 0; i < doors.Count; i++)
        {
            if (door == doors[i].door)
            {
                doors[i].placeholder.SetActive(false);
                doors[i].door.SetActive(true);
                //MapManager.instance.SetIcon(doors[i].xNum, doors[i].xDem, doors[i].yNum, doors[i].yDem, "Treasure", doors[i].id);
                exist = true;
            }
        }

        return exist;
    }

    public static bool RemoveDoor(int id)
    {
        bool exist = false;
        for (int i = 0; i < doors.Count; i++)
        {
            if (id == doors[i].id)
            {
                doors[id].door.SetActive(false);
                doors[id].placeholder.SetActive(true);
                MapManager.instance.DestroyIcon(doors[id].id);
                exist = true;

                completed.Add(doors[i]);
            }
        }
        return exist;
    }

    public static bool RemoveDoor(GameObject door)
    {
        bool exist = false;
        for (int i = 0; i < doors.Count; i++)
        {
            if (door == doors[i].door)
            {
                doors[i].door.SetActive(false);
                doors[i].placeholder.SetActive(true);
                MapManager.instance.DestroyIcon(doors[i].id);
                exist = true;

                completed.Add(doors[i]);
            }
        }

        return exist;
    }
}

[System.Serializable]
public class Door
{
    public GameObject door;
    public GameObject placeholder;
    public int xNum;
    public int xDem;
    public int yNum;
    public int yDem;
    public int id;
}