using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePanel : Panel
{
    #region INSPECTOR PROPERTIES

    [SerializeField] private TextMeshProUGUI currentLevelTXT;
    [SerializeField] private TextMeshProUGUI nextLevelTXT;
    [SerializeField] private ProgressBar progressBar;

    #endregion

    #region UNITY METHODS

    private void Start()
    {
        MainManager.Instance.EventManager.Register(EventTypes.LevelStart, SetLevelBarLevels);
    }

    #endregion

    #region PUBLIC METHODS

    public void SetProgressBarCount(int value)
    {
        progressBar.maxCount = value;
    }

    public void SetProgressBarCurrentCount(int value)
    {
        progressBar.SetCurrentCount(value);
    }

    public void SetLevelBarLevels(EventArgs args)
    {
        var currentLevel = PlayerPrefs.GetInt("Level") + 1;
        currentLevelTXT.text = currentLevel.ToString();
        nextLevelTXT.text = (currentLevel + 1).ToString();
    }

    #endregion
}