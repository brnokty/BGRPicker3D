using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private List<GameObject> levelObjects = new List<GameObject>();


    public void CreateLevel(LevelScriptableObject level)
    {
        float pos = 0;
        for (int i = 0; i < level.LevelObjects.Count; i++)
        {
            var lObj = level.LevelObjects[i];
            if (lObj.LevelObjectType == LevelObjectType.Platform)
            {
                var platform = Instantiate(levelObjects[0], new Vector3(0, 0, pos), Quaternion.identity);
                platform.transform.localScale = new Vector3(1, 1, lObj.value);
                pos += lObj.value;
            }
            else
            {
                var pool = Instantiate(levelObjects[1], new Vector3(0, 0, pos), Quaternion.identity);
                pool.GetComponent<CaseHandler>().SetRequiredCarriableCount(lObj.value);
                pos += 10;
            }
        }

        var finish = Instantiate(levelObjects[2], new Vector3(0, 0, pos), Quaternion.identity);
    }
}