using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : Panel
{
    #region PRIVATE PROPERTIES

    private bool isStarted;

    #endregion

    #region PRIVATE METHODS

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isStarted)
        {
            isStarted = true;
            MainManager.Instance.EventRunner.LevelStart();
            enabled = false;
        }
    }

    #endregion
}