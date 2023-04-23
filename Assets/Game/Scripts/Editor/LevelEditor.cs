using UnityEngine;
using UnityEditor;
using System.IO;

public class LevelEditor : EditorWindow
{
    private string newLevelName = "";
    private string[] levelNames;
    private int selectedLevelIndex = 0;
    private static LevelManagerSO levelManagerSO;


    [MenuItem("Tools/Level Editor")]
    public static void ShowWindow()
    {
        GetWindow<LevelEditor>("Level Editor");
    }

    private void OnEnable()
    {
        levelNames = Directory.GetFiles("Assets/Game/ScriptableObjects/Levels", "*.asset");
        for (int i = 0; i < levelNames.Length; i++)
        {
            levelNames[i] = Path.GetFileNameWithoutExtension(levelNames[i]);
        }


        string path = "Assets/Game/ScriptableObjects/Managers/LevelManagerSO.asset";
        levelManagerSO = AssetDatabase.LoadAssetAtPath<LevelManagerSO>(path);


        UpdateLevelManagerSO();

        EditorUtility.FocusProjectWindow();
    }

    private void UpdateLevelManagerSO()
    {
        levelManagerSO.Levels.Clear();
        for (int i = 0; i < levelNames.Length; i++)
        {
            LevelScriptableObject tempLevelSO =
                AssetDatabase.LoadAssetAtPath<LevelScriptableObject>("Assets/Game/ScriptableObjects/Levels/" +
                                                                     levelNames[i] + ".asset");
            levelManagerSO.Levels.Add(tempLevelSO);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private void OnGUI()
    {
        GUILayout.Label("Level Editor", EditorStyles.boldLabel);

        GUILayout.Space(10f);

        GUILayout.Label("New Level", EditorStyles.boldLabel);

        newLevelName = EditorGUILayout.TextField("Level Name", newLevelName);

        if (GUILayout.Button("Add New Level"))
        {
            if (newLevelName != "")
            {
                LevelScriptableObject levelScriptable = ScriptableObject.CreateInstance<LevelScriptableObject>();
                levelScriptable.name = newLevelName;

                AssetDatabase.CreateAsset(levelScriptable,
                    "Assets/Game/ScriptableObjects/Levels/" + newLevelName + ".asset");
                AssetDatabase.SaveAssets();

                ArrayUtility.Add(ref levelNames, newLevelName);
                selectedLevelIndex = levelNames.Length - 1;

                newLevelName = "";
            }

            UpdateLevelManagerSO();
        }

        GUILayout.Space(10f);

        GUILayout.Label("Levels", EditorStyles.boldLabel);

        selectedLevelIndex = EditorGUILayout.Popup("Select Level", selectedLevelIndex, levelNames);


        if (GUILayout.Button("Open Level"))
        {
            LevelScriptableObject levelScriptableObject =
                AssetDatabase.LoadAssetAtPath<LevelScriptableObject>("Assets/Game/ScriptableObjects/Levels/" +
                                                                     levelNames[selectedLevelIndex] + ".asset");


            LevelEditWindow levelEditWindow = EditorWindow.GetWindow<LevelEditWindow>("Level Edit Window");
            levelEditWindow.DisplayLevel(levelScriptableObject);
        }


        if (GUILayout.Button("Delete Level"))
        {
            if (EditorUtility.DisplayDialog("Delete Level",
                "Are you sure you want to delete " + levelNames[selectedLevelIndex] + "?",
                "Yes",
                "Cancel"))
            {
                string path = "Assets/Game/ScriptableObjects/Levels/" +
                              levelNames[selectedLevelIndex] + ".asset";
                File.Delete(path);
                AssetDatabase.Refresh();
                ArrayUtility.RemoveAt(ref levelNames, selectedLevelIndex);
                selectedLevelIndex = 0;
            }
        }
    }
}