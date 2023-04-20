using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Initialize()
    {
        MainManager.Instance.EventManager.Register(EventTypes.Win, Win);
        MainManager.Instance.EventManager.Register(EventTypes.GameStart, CreateLevel);
    }

    void Start()
    {
        MainManager.Instance.EventRunner.GameStart();
    }

    public void CreateLevel(EventArgs args)
    {
        // MainManager.Instance.LevelManager.CreateLevel();
    }

    public void Win(EventArgs args)
    {
        MainManager.Instance.LevelManager.IncreaseLevelIndex();
    }
    
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}