using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Panel : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    public float appearTime;
    public float disappearTime;

    #endregion

    #region PUBLIC PROPERTIES

    [HideInInspector] public CanvasGroup canvasGroup;

    #endregion

    #region PRIVATE PROPERTIES

    private Coroutine appearDisappearCoroutine;

    #endregion

    #region PUBLIC METHODS

    public virtual void Initialize()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void Appear(EventArgs eventArgs = null)
    {
        StopAppearDisappearCoroutine();
        appearDisappearCoroutine = StartCoroutine(AppearRoutine());
    }


    public IEnumerator AppearRoutine()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / appearTime;
            yield return new WaitForEndOfFrame();
        }

        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public virtual void Disappear()
    {
        StopAppearDisappearCoroutine();
        appearDisappearCoroutine = StartCoroutine(DisappearRoutine());
    }

    public IEnumerator DisappearRoutine()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / disappearTime;
            yield return new WaitForEndOfFrame();
        }

        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    #endregion

    #region PRIVATE METHODS

    private void StopAppearDisappearCoroutine()
    {
        if (appearDisappearCoroutine != null)
        {
            StopCoroutine(appearDisappearCoroutine);
        }
    }

    #endregion
}