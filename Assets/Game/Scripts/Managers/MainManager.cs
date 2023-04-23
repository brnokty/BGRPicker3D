using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    public LevelManager LevelManager;
    public GameManager GameManager;
    public UIManager UIManager;
    public EventManager EventManager;
    public EventRunner EventRunner;

    #endregion

    #region Singleton

    public static MainManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        Initialize();
    }

    #endregion

    #region PUBLIC METHODS

    private void Initialize()
    {
        EventManager.Initialize();
        GameManager.Initialize();
        UIManager.Initialize();
    }

    #endregion
}