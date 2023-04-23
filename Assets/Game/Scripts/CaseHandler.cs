using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CaseHandler : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private Transform leftStrip;
    [SerializeField] private Transform rightStrip;
    [SerializeField] private Transform cube;

    #endregion

    #region PUBLIC PROPERTIES

    [HideInInspector] public int requiredCarriableCount = 10;
    [HideInInspector] public bool isFull;

    #endregion

    #region PRIVATE PROPERTIES

    private int currentCarriableCount = 0;
    private List<Rigidbody> rigidbodies = new List<Rigidbody>();

    #endregion

    #region PUBLIC METHODS

    public void AddCarriable(Rigidbody rb)
    {
        currentCarriableCount++;
        if (currentCarriableCount >= requiredCarriableCount && !isFull)
        {
            isFull = true;
            textMeshPro.color = Color.green;
            StartCoroutine(PassStage());
        }


        rigidbodies.Add(rb);
        textMeshPro.text = currentCarriableCount + " / " + requiredCarriableCount;
    }

    public void SetRequiredCarriableCount(int value)
    {
        requiredCarriableCount = value;
        textMeshPro.text = currentCarriableCount + " / " + requiredCarriableCount;
    }

    public IEnumerator PassStage()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < rigidbodies.Count; i++)
        {
            rigidbodies[i].isKinematic = true;
        }

        leftStrip.DOLocalRotate(new Vector3(180, 270, 270), 0.5f);
        rightStrip.DOLocalRotate(new Vector3(180, 90, 90), 0.5f);
        cube.DOLocalMove(new Vector3(0, -0.25f, 5), 0.5f);
        cube.DOScale(new Vector3(8, 0.5f, 10.2f), 0.5f);
        yield return new WaitForSeconds(0.6f);
        MainManager.Instance.EventRunner.KeepMove();
    }

    #endregion
}