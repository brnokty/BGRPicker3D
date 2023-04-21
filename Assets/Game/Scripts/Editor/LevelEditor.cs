using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelEditor : EditorWindow
{
    private static LevelManagerSO levelManagerSO;


    [MenuItem("Window/Level Editor")]
    public static void ShowWindow()
    {
        LevelEditor window = EditorWindow.GetWindow<LevelEditor>();
        window.titleContent = new GUIContent("Level Editor");
        FindSO();
        window.Show();
    }

    private static void FindSO()
    {
        levelManagerSO = ScriptableObject.CreateInstance<LevelManagerSO>();
        string path = "Assets/Game/ScriptableObjects/Managers/LevelManagerSO.asset";
        AssetDatabase.CreateAsset(levelManagerSO, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = levelManagerSO;
    }

    void OnGUI()
    {
        if (levelManagerSO != null)
        {
            SerializedObject serializedObject = new SerializedObject(levelManagerSO);
            SerializedProperty property = serializedObject.GetIterator();
            while (property.NextVisible(true))
            {
                if (property.name != "m_Script")
                {
                    EditorGUILayout.PropertyField(property, false);
                }
            }

            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Refresh"))
            {
                Debug.Log("Butona tıklandı!");
            }
        }
    }
}