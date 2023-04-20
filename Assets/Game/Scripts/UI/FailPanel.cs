using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPanel : Panel
{
    public void ButtonClick()
    {
        MainManager.Instance.GameManager.Restart();
    }
}