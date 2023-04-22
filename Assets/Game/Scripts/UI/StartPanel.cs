using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : Panel
{
    private bool isStarted;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isStarted)
        {
            isStarted = true;
            MainManager.Instance.EventRunner.LevelStart();
            enabled = false;
        }
    }
}