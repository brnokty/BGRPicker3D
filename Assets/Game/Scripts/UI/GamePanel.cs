using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePanel : Panel
{
    [SerializeField] private TextMeshProUGUI currentLevelTXT;
    [SerializeField] private TextMeshProUGUI nextLevelTXT;
    [SerializeField] private ProgressBar progressBar;
    // public BoardHandler boardHandler;


    private void Start()
    {
        MainManager.Instance.EventManager.Register(EventTypes.LevelStart, SetLevelBarLevels);
    }

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
}