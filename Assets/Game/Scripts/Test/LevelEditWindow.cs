using System;
using UnityEngine;
using UnityEditor;

public class LevelEditWindow : EditorWindow
{
    private LevelScriptableObject levelScriptableObject;


    private string[] objectNames;
    private int selectedObjectIndex = 0;
    private Vector3 objectPosition = Vector3.zero;
    private Quaternion objectRotation = Quaternion.identity;

    private int levelCompleteCount = 0;

    public void DisplayLevel(LevelScriptableObject levelScriptableObject)
    {
        this.levelScriptableObject = levelScriptableObject;
        Show();
    }

    private void OnGUI()
    {
        if (levelScriptableObject == null)
        {
            GUILayout.Label("No level selected.", EditorStyles.boldLabel);
            return;
        }

        GUILayout.Label(levelScriptableObject.name, EditorStyles.boldLabel);

        GUILayout.Space(10f);

        GUILayout.Label("Level Objects", EditorStyles.boldLabel);

        for (int i = 0; i < levelScriptableObject.objects.Count; i++)
        {
            GUILayout.Label(levelScriptableObject.objects[i].name);
        }

        SerializedObject serializedObject = new SerializedObject(levelScriptableObject);
        SerializedProperty property = serializedObject.FindProperty("LevelObjects");
        // while (property.NextVisible(false))
        // {


        EditorGUILayout.PropertyField(property, true);

        // }
        serializedObject.ApplyModifiedProperties();

        GUILayout.Space(10f);

        GUILayout.Label("Level Complete Count", EditorStyles.boldLabel);

        levelScriptableObject.levelCompleteCount =
            EditorGUILayout.IntField("Level Complete Count", levelScriptableObject.levelCompleteCount);

        if (GUILayout.Button("Save Level"))
        {
            EditorUtility.SetDirty(levelScriptableObject);
            AssetDatabase.SaveAssets();
        }
    }
}