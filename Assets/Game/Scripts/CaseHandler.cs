using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaseHandler : MonoBehaviour
{
    public int requiredCarriableCount = 10;
    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private Transform leftStrip;
    [SerializeField] private Transform rightStrip;
    private int currentCarriableCount = 10;


    public void AddCarriable()
    {
        currentCarriableCount++;

        if (currentCarriableCount>=10)
        {
            textMeshPro.color=Color.green;
        }

        textMeshPro.text = currentCarriableCount + " / " + requiredCarriableCount;
    }
}