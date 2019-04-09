using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public r
    public enum Fraction { Medio, Tercio, Cuarto, Octavo }
    public Fraction horizontal = Fraction.Medio;
    public Fraction vertical = Fraction.Medio;
    private int row;
    private int column;

    private void Start()
    {
        
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {

            }
        }   
    }

    private void SetFractions()
    {
        switch (horizontal)
        {
            case Fraction.Medio:
                row = 2;
                break;
            case Fraction.Tercio:
                row = 3;
                break;
            case Fraction.Cuarto:
                row = 4;
                break;
            case Fraction.Octavo:
                row = 8;
                break;
        }
        switch (vertical)
        {
            case Fraction.Medio:
                column = 2;
                break;
            case Fraction.Tercio:
                column = 3;
                break;
            case Fraction.Cuarto:
                column = 4;
                break;
            case Fraction.Octavo:
                column = 8;
                break;
        }
    }
}