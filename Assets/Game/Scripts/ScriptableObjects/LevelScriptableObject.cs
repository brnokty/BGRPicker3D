using System;
using System.Collections.Generic;
using UnityEngine;


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
    public Vector3 position;
    public Vector3 rotation;
}


[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class LevelScriptableObject : ScriptableObject
{
    [SerializeField] public List<LevelObject> LevelObjects = new List<LevelObject>();
    [SerializeField] public List<CarriableObject> CarriableObjects = new List<CarriableObject>();


    public List<GameObject> objects = new List<GameObject>();


    // public int levelCompleteCount = 0;

    public void AddObject(GameObject obj)
    {
        objects.Add(obj);
    }

    public void DeleteObject(string objName)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].name == objName)
            {
                DestroyImmediate(objects[i]);
                objects.RemoveAt(i);
                break;
            }
        }
    }

    public void UpdateObjectPosition(string objName, Vector3 newPos)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].name == objName)
            {
                objects[i].transform.position = newPos;
                break;
            }
        }
    }

    public void UpdateObjectRotation(string objName, Quaternion newRot)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].name == objName)
            {
                objects[i].transform.rotation = newRot;
                break;
            }
        }
    }

    // public void UpdateLevelCompleteCount(int newCount)
    // {
    //     levelCompleteCount = newCount;
    // }

    public void UpdateLevel()
    {
        Debug.Log("Level updated.");
    }
}