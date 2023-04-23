using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : Panel
{
    #region PUBLIC METHODS

    public void ButtonClick()
    {
        MainManager.Instance.GameManager.Restart();
    }

    #endregion
}