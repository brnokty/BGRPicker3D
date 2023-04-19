using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Level - ", menuName = "ScriptableObjects/LevelSO", order = 1)]
public class LevelSO : ScriptableObject
{
    public int levelSize = 500;
}