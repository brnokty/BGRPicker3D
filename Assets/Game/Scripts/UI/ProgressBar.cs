using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    public int maxCount = 10;
    public float currentCount = 0;

    [SerializeField] private Image Fill;

    #endregion

    #region PRIVATE PROPERTIES

    private float deger = 0;
    private Tween fillTween;

    #endregion

    #region PUBLIC METHODS

    public void ResetProgress()
    {
        currentCount = 0;
        Fill.fillAmount = currentCount;
    }


    public void SetCurrentCount(float count)
    {
        currentCount = count;

        gameObject.SetActive(true);

        deger = (1f / (float) maxCount) * count;

        fillTween?.Kill();
        fillTween = Fill.DOFillAmount(deger, 0.1f);
    }


    public void GoMax(float time)
    {
        fillTween?.Kill();
        fillTween = Fill.DOFillAmount(1, time);
    }

    #endregion
}