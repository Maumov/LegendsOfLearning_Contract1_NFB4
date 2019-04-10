using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Material Grid;
    //public enum Fraction { Medio, Tercio, Cuarto, Octavo }
    //public Fraction horizontal = Fraction.Medio;
    //public Fraction vertical = Fraction.Medio;
    public List<int> fractions = new List<int>();
    private int xIndex = 1;
    private int yIndex = 1;
    private int indexMaxValue;

    private void Start()
    {
        for(int i=0; i < fractions.Count; i++)
        {
            if(fractions[i] == 0)
            {
                fractions[i] = 1;
            }
        }
        indexMaxValue = fractions.Count - 1;

        Grid.SetFloat("_GridXSize", fractions[xIndex]);
        Grid.SetFloat("_GridYSize", fractions[yIndex]);
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

        Grid.SetFloat("_GridYSize", fractions[yIndex]);
    }
}