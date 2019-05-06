using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    RectTransform rectT;
    [Header("Prefabs & objects")]
    public Transform grid;
    public GameObject FractionPrefab;
    public GameObject horizontalParent;
    public GameObject verticalParent;
    public GameObject line;
    public List<MapIconPrefab> icons;

    [Header("SetupLine")]
    [Range(0f, 10f)]
    public float lineSize;
    public Color colorX;
    public Color colorY;

    private List<GameObject> prefabsX = new List<GameObject>();
    private List<GameObject> prefabsY = new List<GameObject>();
    private List<GameObject> linesX = new List<GameObject>();
    private List<GameObject> linesY = new List<GameObject>();

    public List<int> fractions = new List<int>();
    private int xIndex = 3;
    private int yIndex = 2;
    private int indexMaxValue;
    private float xOffset;
    private float yOffset;

    private void Start()
    {
        rectT = GetComponent<RectTransform>();
        SetFraction offset = FractionPrefab.GetComponent<SetFraction>();

        xOffset = offset.numerator.rectTransform.rect.width;
        yOffset = (offset.numerator.rectTransform.position.y - offset.demoninator.rectTransform.position.y);

        indexMaxValue = fractions.Count - 1;

        xIndex = MapManager.index.x;
        yIndex = MapManager.index.y;

        FinalFraction();
        SetHorizontal("Start");
        SetVertical("Start");

        SpawnIcons();
    }

    public void SetHorizontal(string result)
    {
        if (result == "+")
        {
            if (xIndex >= indexMaxValue)
            {
                return;
            }
            else
            {
                xIndex++;
            }
        }
        else if (result == "-")
        {
            if (xIndex <= 0)
            {
                return;
            }
            else
            {
                xIndex--;
            }
        }

        prefabsX.ForEach((t) => { Destroy(t); });
        prefabsX.Clear();
        linesX.ForEach((t) => { Destroy(t); });
        linesX.Clear();

        for (int i = 1; i < fractions[xIndex]; i++)
        {
            linesX.Add(Instantiate(line, grid));
            RectTransform temp = linesX[i - 1].GetComponent<RectTransform>();
            temp.sizeDelta = new Vector2(lineSize, rectT.rect.height);
            temp.GetComponent<RawImage>().color = colorX;
            temp.anchoredPosition = new Vector2((rectT.rect.width / fractions[xIndex]) * i, 0f);
        }

        for (int i = 1; i < fractions[xIndex]; i++)
        {
            prefabsX.Add(Instantiate(FractionPrefab, horizontalParent.transform));
            SetFraction fraction = prefabsX[i - 1].GetComponent<SetFraction>();
            fraction.SetNumerator(i);
            fraction.SetDenominator(fractions[xIndex]);
            fraction.SetPosition((rectT.rect.width / fractions[xIndex]) * i, -rectT.rect.height);
        }
    }

    public void SetVertical(string result)
    {
        if (result == "+")
        {
            if (yIndex >= indexMaxValue)
            {
                return;
            }
            else
            {
                yIndex++;
            }
        }
        else if (result == "-")
        {
            if (yIndex <= 0)
            {
                return;
            }
            else
            {
                yIndex--;
            }
        }

        prefabsY.ForEach((t) => { Destroy(t); });
        prefabsY.Clear();
        linesY.ForEach((t) => { Destroy(t); });
        linesY.Clear();

        for (int i = 1; i < fractions[yIndex]; i++)
        {
            linesY.Add(Instantiate(line, grid));
            RectTransform temp = linesY[i - 1].GetComponent<RectTransform>();
            temp.sizeDelta = new Vector2(lineSize, rectT.rect.width);
            temp.rotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
            temp.GetComponent<RawImage>().color = colorY;
            temp.anchoredPosition = new Vector2(0f, -(rectT.rect.height / fractions[yIndex]) * i);
        }

        for (int i = 1; i < fractions[yIndex]; i++)
        {
            prefabsY.Add(Instantiate(FractionPrefab, verticalParent.transform));
            SetFraction fraction = prefabsY[i - 1].GetComponent<SetFraction>();
            fraction.SetNumerator(i);
            fraction.SetDenominator(fractions[yIndex]);
            fraction.SetPosition(rectT.rect.width + xOffset, -(rectT.rect.height / fractions[yIndex]) * i + yOffset);
        }


    }

    // Optional
    private void FinalFraction()
    {
        prefabsX.Add(Instantiate(FractionPrefab, verticalParent.transform));
        SetFraction fraction = prefabsX[prefabsX.Count - 1].GetComponent<SetFraction>();
        fraction.SetNumerator(1);
        fraction.SetDenominator(1);
        fraction.SetPosition(rectT.rect.width + xOffset / 2, -rectT.rect.height);
    }

    public void SetModuleFractions(int x, int y)
    {
        xIndex = fractions.IndexOf(x);
        yIndex = fractions.IndexOf(y);

        SetHorizontal("Start");
        SetVertical("Start");
    }

    private void SpawnIcons()
    {
        for (int i = 0; i < MapManager.instance.icons.Count; i++)
        {
            MapIconPrefab iconScript = Instantiate(MapManager.instance.icons[i], transform).GetComponent<MapIconPrefab>();
            icons.Add(iconScript);
            iconScript.GetComponent<RawImage>().rectTransform.anchoredPosition = new Vector2(rectT.rect.width * iconScript.position.x, rectT.rect.height * -iconScript.position.y);
            if (iconScript.status)
            {
                iconScript.ActivateIcon();
            }
        }
    }

    public bool CheckForIconIndex(Vector2 index)
    {
        if (index.Equals(new Vector2(fractions[xIndex], fractions[yIndex])))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SaveIndex()
    {
        MapManager.index = new Vector2Int(xIndex, yIndex);
    }
}