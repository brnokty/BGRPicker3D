using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public int maxCount = 10;
    public float currentCount = 0;

    [SerializeField] private Image Fill;

    private float deger = 0;
    private Tween fillTween;


    public void ResetProgress()
    {
        currentCount = 0;
        Fill.fillAmount = currentCount;
        // fillTween?.Kill();
        // fillTween = Fill.DOFillAmount(0, 0f);
    }


    public void SetCurrentCount(float count)
    {
        currentCount = count;
        // if (currentCount > maxCount / 2)
        // {
        //     Fill.DOColor(new Color(0, 0.9f, 0.5f), 0.2f);
        // }
        // else if (currentCount < maxCount / 4f)
        // {
        //     Fill.DOColor(new Color(1, 0.2f, 0.5f), 0.2f);
        // }
        // else if (currentCount < maxCount / 4 * 3)
        // {
        //     Fill.DOColor(new Color(1, 0.9f, 0.5f), 0.2f);
        // }
        gameObject.SetActive(true);

        deger = (1f / (float) maxCount) * count;

        fillTween?.Kill();
        fillTween = Fill.DOFillAmount(deger, 0.1f);
        //text.text = currentCount.ToString();
    }


    public void GoMax(float time)
    {
        fillTween?.Kill();
        fillTween = Fill.DOFillAmount(1, time);
    }
}