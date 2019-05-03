using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DoorsManager
{
    public static List<Door> doors = new List<Door>();

    public static bool SpawnDoor(int index)
    {
        if (index >= 0 && index < doors.Count)
        {
            doors[index].placeholder.SetActive(false);
            doors[index].door.SetActive(true);
            MapManager.instance.SetIcon(doors[index].xNum, doors[index].xDem, doors[index].yNum, doors[index].yDem, "Treasure", doors[index].id);
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool SpawnDoor(GameObject door)
    {
        for (int i = 0; i < doors.Count; i++)
        {
            if (door == doors[i].door)
            {
                doors[i].placeholder.SetActive(false);
                doors[i].door.SetActive(true);
                MapManager.instance.SetIcon(doors[i].xNum, doors[i].xDem, doors[i].yNum, doors[i].yDem, "Treasure", doors[i].id);
                return true;
            }
        }

        return false;
    }

    public static bool RemoveDoor(int index)
    {
        if (index >= 0 && index < doors.Count)
        {
            doors[index].door.SetActive(false);
            doors[index].placeholder.SetActive(true);
            MapManager.instance.DestroyIcon(doors[index].id);
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool RemoveDoor(GameObject door)
    {
        for (int i = 0; i < doors.Count; i++)
        {
            if (door == doors[i].door)
            {
                doors[i].door.SetActive(false);
                doors[i].placeholder.SetActive(true);
                MapManager.instance.DestroyIcon(doors[i].id);
                return true;
            }
        }

        return false;
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