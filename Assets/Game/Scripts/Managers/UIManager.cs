using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    public GamePanel GamePanel;
    public WinPanel WinPanel;
    public FailPanel FailPanel;
    public StartPanel StartPanel;

    #endregion

    #region PUBLIC METHODS

    public void Initialize()
    {
        GamePanel.Initialize();
        WinPanel.Initialize();
        FailPanel.Initialize();
        StartPanel.Initialize();
        MainManager.Instance.EventManager.Register(EventTypes.LevelStart, LevelStart);
        MainManager.Instance.EventManager.Register(EventTypes.Win, LevelSuccess);
        MainManager.Instance.EventManager.Register(EventTypes.Fail, LevelFail);
    }

    #endregion

    #region PRIVATE METHODS

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

    #endregion
}