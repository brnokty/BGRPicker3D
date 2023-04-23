using System;
using System.Collections.Generic;
using UnityEngine;

#region ENUMS

public enum LevelObjectType
{
    Platform,
    Pool
}

public enum CarriableObjectType
{
    Capsule,
    Cube,
    Sphere
}

#endregion

#region STRUCTS

[Serializable]
public struct LevelObject
{
    public LevelObjectType LevelObjectType;
    public int value;
}

[Serializable]
public struct CarriableObject
{
    public CarriableObjectType CarriableObjectType;
    public bool randomX;
    public Vector3 position;
    public Vector3 rotation;
}

#endregion

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class LevelScriptableObject : ScriptableObject
{
    #region INSPECTOR PROPERTIES

    [SerializeField] public List<LevelObject> LevelObjects = new List<LevelObject>();
    [SerializeField] public List<CarriableObject> CarriableObjects = new List<CarriableObject>();

    #endregion
}