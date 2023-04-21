using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelManagerSO", menuName = "ScriptableObjects/LevelManagerSO", order = 0)]
public class LevelManagerSO : ScriptableObject
{
    public List<Carriable> Carriables;
    public List<LevelSO> Levels;
}
