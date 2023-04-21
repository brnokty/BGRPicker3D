using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LevelObjEnum
{
    Platform,
    Case
}

[Serializable]
public struct LevelObj
{
    public LevelObjEnum LevelObjEnum;
    public float platformSize;
    public int caseRequiredCarriableCount;
}

[Serializable]
[CreateAssetMenu(fileName = "Level - ", menuName = "ScriptableObjects/LevelSO", order = 1)]
public class LevelSO : ScriptableObject
{
    public List<LevelObj> LevelObjs = new List<LevelObj>();
}