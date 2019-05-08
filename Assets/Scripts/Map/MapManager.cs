using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [Header("Extra")]
    public AudioSource audioSource;
    public List<Door> doors = DoorsManager.doors;

    [Header("Canvas & Map")]
    public Transform canvas;
    public GameObject MapUI;
    [HideInInspector] public static bool isMapOpen = false;

    [Header("Grid & current icons")]
    public GameObject Iconprefab;
    public List<GameObject> icons;
    public List<Texture> textures;
    public static Vector2Int index = new Vector2Int(1, 1);

    public static MapManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        SetIcon(1, 8, 3, 10, "Treasure", 1);
        SetIcon(2, 9, 7, 10, "Treasure", 2);
        SetIcon(4, 9, 5, 6, "Treasure", 3);
        SetIcon(5, 8, 3, 9, "Treasure", 4);

        for (int i = 0; i < doors.Count; i++)
        {
            doors[i].door.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            SpawnMap();
        }
    }

    public void SetIcon(int xNum, int xDem, int yNum, int yDem, string icon, int id)
    {
        icons.Add(Instantiate(Iconprefab, transform));
        RawImage imageTexture = icons[icons.Count - 1].GetComponent<RawImage>();
        MapIconPrefab imageScript = imageTexture.GetComponent<MapIconPrefab>();
        imageScript.gameObject.name = id.ToString();
        imageScript.arrayIndex = icons.Count - 1;
        imageScript.id = id;
        imageScript.numerators = new Vector2(xNum, yNum);
        imageScript.denimators = new Vector2(xDem, yDem);
        imageScript.position = new Vector2((float)xNum / xDem, (float)yNum / yDem);
        for (int i = 0; i < textures.Count; i++)
        {
            if (textures[i].name.Contains(icon))
            {
                imageTexture.texture = textures[i];
            }
        }
    }

    public void DestroyIcon(int id)
    {
        for (int i = 0; i < icons.Count; i++)
        {
            if (icons[i].GetComponent<MapIconPrefab>().id == id)
            {
                Destroy(icons[i].gameObject);
                icons.Remove(icons[i]);
            }
        }   
    }

    public void SpawnMap()
    {
        if (isMapOpen == false)
        {
            isMapOpen = true;
            GameManager.EnableCursor();
            Instantiate(MapUI, canvas);
        }
    }
}