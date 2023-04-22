using UnityEditor;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Level properties
    public string levelName = "";
    public int levelCompleteCount = 0;

    // List of objects in the level
    public GameObject[] objects;

    // Add a new object to the level
    public void AddObject(GameObject newObject)
    {
        ArrayUtility.Add(ref objects, newObject);
    }

    // Delete an object from the level
    public void DeleteObject(string objectName)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].name == objectName)
            {
                ArrayUtility.RemoveAt(ref objects, i);
                DestroyImmediate(objects[i]);
                break;
            }
        }
    }

    // Update the position of an object in the level
    public void UpdateObjectPosition(string objectName, Vector3 newPosition)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].name == objectName)
            {
                objects[i].transform.position = newPosition;
                break;
            }
        }
    }

    // Update the rotation of an object in the level
    public void UpdateObjectRotation(string objectName, Quaternion newRotation)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].name == objectName)
            {
                objects[i].transform.rotation = newRotation;
                break;
            }
        }
    }

    // Update the level complete count
    public void UpdateLevelCompleteCount(int newCount)
    {
        levelCompleteCount = newCount;
    }

    // Update the level properties
    public void UpdateLevel()
    {
        // Update the level name
        gameObject.name = levelName;

        // Update the objects in the level
        foreach (GameObject obj in objects)
        {
            obj.transform.parent = transform;
        }
    }
}