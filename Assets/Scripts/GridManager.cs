using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    RectTransform rectT;
    [Header("Prefabs & objects")]
    public Material Grid;
    public GameObject FractionPrefab;
    public GameObject horizontalParent;
    public GameObject verticalParent;
    public List<MapIconPrefab> icons;

    private List<GameObject> prefabsX = new List<GameObject>();
    private List<GameObject> prefabsY = new List<GameObject>();

    public List<int> fractions = new List<int>();
    [Range(0f, 0.1f)]
    public List<float> linesXSize = new List<float>();
    [Range(0f, 0.1f)]
    public List<float> linesYSize = new List<float>();
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

        /*
        linesXSize.Capacity = fractions.Capacity;
        linesYSize.Capacity = fractions.Capacity;

        for (int i=0; i < fractions.Count; i++)
        {
            if(fractions[i] == 0)
            {
                fractions[i] = 1;
            }
            if(i >0 && linesXSize[i] == 0)
            {
                linesXSize[i] = 0.01f;
            }
            if (i > 0 && linesYSize[i] == 0)
            {
                linesYSize[i] = 0.01f;
            }
        }
        */

        indexMaxValue = fractions.Count - 1;

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
        else if(result == "-")
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

        for(int i = 1; i < fractions[xIndex]; i++)
        {
            prefabsX.Add(Instantiate(FractionPrefab, horizontalParent.transform));
            SetFraction fraction = prefabsX[i-1].GetComponent<SetFraction>();
            fraction.SetNumerator(i);
            fraction.SetDenominator(fractions[xIndex]);
            fraction.SetPosition((rectT.rect.width / fractions[xIndex]) * i, -rectT.rect.height);
        }

        // Check Icons
        CheckForIconIndex();

        Grid.SetFloat("_LineXSize", linesXSize[xIndex]);
        Grid.SetFloat("_GridXSize", fractions[xIndex]);
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

        for (int i = 1; i < fractions[yIndex]; i++)
        {
            prefabsY.Add(Instantiate(FractionPrefab, verticalParent.transform));
            SetFraction fraction = prefabsY[i-1].GetComponent<SetFraction>();
            fraction.SetNumerator(i);
            fraction.SetDenominator(fractions[yIndex]);
            fraction.SetPosition(rectT.rect.width + xOffset, -(rectT.rect.height / fractions[yIndex]) * i + yOffset);
        }

        // Check Icons
        CheckForIconIndex();

        Grid.SetFloat("_LineYSize", linesYSize[yIndex]);
        Grid.SetFloat("_GridYSize", fractions[yIndex]);
    }

    // Optional
    private void FinalFraction()
    {
        prefabsX.Add(Instantiate(FractionPrefab, verticalParent.transform));
        SetFraction fraction = prefabsX[prefabsX.Count-1].GetComponent<SetFraction>();
        fraction.SetNumerator(1);
        fraction.SetDenominator(1);
        fraction.SetPosition(rectT.rect.width + xOffset/2, -rectT.rect.height);
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
            iconScript.gameObject.transform.parent = transform;
            Debug.Log(iconScript.status);
            iconScript.gameObject.SetActive(iconScript.status);
            iconScript.GetComponent<RawImage>().rectTransform.anchoredPosition = new Vector2(rectT.rect.width * iconScript.position.x, rectT.rect.height * -iconScript.position.y);
        }
    }

    private void CheckForIconIndex()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            Debug.Log(icons[i].index + "  " + new Vector2(fractions[xIndex], fractions[yIndex]) + "   " + icons[i].status);
            if (icons[i].index.Equals(new Vector2(fractions[xIndex], fractions[yIndex])) && icons[i].status == false)
            {
                MapManager.instance.icons[i].GetComponent<MapIconPrefab>().status = true;
                icons[i].gameObject.SetActive(true);
                if(MapManager.instance.audioSource != null)
                {
                    MapManager.instance.audioSource.Play();
                }
            }
        }
    }
}