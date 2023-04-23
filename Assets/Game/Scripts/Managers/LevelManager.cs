using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    public LevelManagerSO LevelManagerSO;
    [SerializeField] private LevelCreator levelCreator;

    #endregion

    #region PUBLIC PROPERTIES

    [HideInInspector] public int LevelNumber;

    #endregion

    #region PRIVATE PROPERTIES

    private LevelScriptableObject level;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        LevelNumber = PlayerPrefs.GetInt("Level", 0);
    }

    #endregion

    #region PUBLIC METHODS

    public void IncreaseLevelIndex()
    {
        SetLevelIndex((LevelNumber + 1));
    }


    public void CreateLevel()
    {
        // if (level != null)
        // {
        //     Destroy(level);
        // }

        level = LevelManagerSO.Levels[LevelNumber % LevelManagerSO.Levels.Count];
        levelCreator.CreateLevel(level);
    }

    #endregion

    #region PRIVATE METHODS

    private void SetLevelIndex(int index)
    {
        LevelNumber = index;
        PlayerPrefs.SetInt("Level", LevelNumber);
    }

    #endregion
}