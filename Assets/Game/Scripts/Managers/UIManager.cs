using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GamePanel GamePanel;
    public WinPanel WinPanel;
    public FailPanel FailPanel;
    public StartPanel StartPanel;


    public void Initialize()
    {
        GamePanel.Initialize();
        WinPanel.Initialize();
        FailPanel.Initialize();
        StartPanel.Initialize();
        MainManager.Instance.EventManager.Register(EventTypes.LevelStart, LevelStart);
        MainManager.Instance.EventManager.Register(EventTypes.Win, LevelSuccess);
        MainManager.Instance.EventManager.Register(EventTypes.Fail, LevelFail);
        // MainManager.Instance.EventManager.Register(EventTypes.BouncedOnTrampoline, BouncedOnTrampoline);
    }

    private void LevelStart(EventArgs args)
    {
        StartPanel.Disappear();
        GamePanel.Appear();
    }

    private void LevelSuccess(EventArgs args)
    {
        GamePanel.Disappear();
        WinPanel.Appear();
    }

    private void LevelFail(EventArgs args)
    {
        GamePanel.Disappear();
        FailPanel.Appear();
    }

    private void BouncedOnTrampoline(EventArgs args)
    {
        int number = (args as IntArgs).value;
        GamePanel.SetProgressBarCurrentCount(number);
    }
}