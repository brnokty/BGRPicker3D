using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private List<GameObject> levelObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> carriableObjects = new List<GameObject>();


    public void CreateLevel(LevelScriptableObject level)
    {
        float pos = 0;
        var startPlatform = Instantiate(levelObjects[0], new Vector3(0, 0, -10), Quaternion.identity);
        startPlatform.transform.localScale = new Vector3(1, 1, 10);

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

        for (int i = 0; i < level.CarriableObjects.Count; i++)
        {
            var cObj = level.CarriableObjects[i];
            if (cObj.CarriableObjectType == CarriableObjectType.Capsule)
            {
                var capsule = Instantiate(carriableObjects[0], cObj.position, Quaternion.Euler(cObj.rotation));
            }
            else if (cObj.CarriableObjectType == CarriableObjectType.Cube)
            {
                var cube = Instantiate(carriableObjects[1], cObj.position, Quaternion.Euler(cObj.rotation));
            }
            else
            {
                var sphere = Instantiate(carriableObjects[2], cObj.position, Quaternion.Euler(cObj.rotation));
            }
        }
    }
}