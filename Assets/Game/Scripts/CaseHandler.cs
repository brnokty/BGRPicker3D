using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CaseHandler : MonoBehaviour
{
    public int requiredCarriableCount = 10;
    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private Transform leftStrip;
    [SerializeField] private Transform rightStrip;
    [SerializeField] private Transform cube;
    private int currentCarriableCount = 0;
    private bool isFull;


    public void AddCarriable()
    {
        currentCarriableCount++;

        if (currentCarriableCount >= requiredCarriableCount && !isFull)
        {
            isFull = true;
            textMeshPro.color = Color.green;
            PassStage();
        }

        textMeshPro.text = currentCarriableCount + " / " + requiredCarriableCount;
    }


    public void PassStage()
    {
        leftStrip.DOLocalRotate(new Vector3(180, 270, 270), 0.5f);
        rightStrip.DOLocalRotate(new Vector3(180, 90, 90), 0.5f);
        cube.DOLocalMove(new Vector3(0, -0.25f, 5), 0.5f);
        cube.DOScale(new Vector3(8, 0.5f, 10), 0.5f).OnComplete(() => { MainManager.Instance.EventRunner.KeepMove(); });
    }
}