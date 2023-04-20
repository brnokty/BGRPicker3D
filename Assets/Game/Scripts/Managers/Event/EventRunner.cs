using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRunner : MonoBehaviour
{
    public void GameStart()
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.GameStart, new EventArgs());
    }


    public void LevelStart()
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.LevelStart, new IntArgs(PlayerPrefs.GetInt("Level")));
    }


    public void BouncedOnTrampoline(int trampolineNumber)
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.BouncedOnTrampoline, new IntArgs(trampolineNumber));
    }

    public void KeepMove()
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.KeepMove);
    }

    public void Fail()
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.Fail);
    }

    public void Win()
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.Win);
    }
}