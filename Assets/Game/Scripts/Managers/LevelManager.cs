using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public int LevelNumber;
    public List<GameObject> Levels = new List<GameObject>();
    private GameObject level;

    private void Awake()
    {
        LevelNumber = PlayerPrefs.GetInt("Level", 0);
    }


    public void IncreaseLevelIndex()
    {
        SetLevelIndex((LevelNumber + 1));
    }

    private void SetLevelIndex(int index)
    {
        LevelNumber = index;
        PlayerPrefs.SetInt("Level", LevelNumber);
    }


    public void CreateLevel()
    {
        if (level != null)
        {
            Destroy(level);
        }

        level = Instantiate(Levels[LevelNumber % Levels.Count], Vector3.zero, Quaternion.identity);
        MainManager.Instance.EventRunner.LevelStart();
    }
}