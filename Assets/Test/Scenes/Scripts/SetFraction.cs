using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SetFraction : MonoBehaviour
{
    public GameObject sandUp;
    public GameObject sandDown;

    public InputField inputNum;
    public InputField inputDem;

    GameObject target;

    private void Start()
    {
        target = sandUp;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.parent.name.Contains("Cone"))
            {
                target = hitInfo.transform.parent.gameObject;
                Debug.Log(target.name);
            }
        }
    }

    void SetScale(float numerator, float denominator)
    {
        float result = numerator / denominator;

        if (result >= 0 && result <= 1)
        {
            if (target == sandUp)
            {
                sandUp.transform.localScale = new Vector3(1f, 1f, result);
            }
            else if (target == sandDown)
            {
                sandDown.transform.localScale = new Vector3(1f, 1f, result);
            }
            Debug.Log(target.name + " scale set to: " + numerator + "/" + denominator);
        }
        else
        {
            return;
        }
    }

    public void ResetScale()
    {
        sandUp.transform.localScale = new Vector3(1f, 1f, 1f);
        sandDown.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void TriggerScale()
    {
        if (inputNum.text.Length == 0 || inputDem.text.Length == 0)
        {
            return;
        }
        SetScale(float.Parse(inputNum.text), float.Parse(inputDem.text));
    }
}