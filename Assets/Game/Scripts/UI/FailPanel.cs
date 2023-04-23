using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPanel : Panel
{
    #region PUBLIC METHODS

    public void ButtonClick()
    {
        MainManager.Instance.GameManager.Restart();
    }

    #endregion
}