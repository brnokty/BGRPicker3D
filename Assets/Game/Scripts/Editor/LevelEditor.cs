using UnityEngine;
using UnityEditor;
using System.IO;

public class LevelEditor : EditorWindow
{
    private string newLevelName = "";
    private string[] levelNames;
    private int selectedLevelIndex = 0;


    [MenuItem("Window/Level Editor")]
    public static void ShowWindow()
    {
        GetWindow<LevelEditor>("Level Editor");
    }

    private void OnEnable()
    {
        levelNames = Directory.GetFiles(Application.dataPath + "/Game/ScriptableObjects/Levels", "*.asset");
        for (int i = 0; i < levelNames.Length; i++)
        {
            levelNames[i] = Path.GetFileNameWithoutExtension(levelNames[i]);
        }
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
                // Create a new empty ScriptableObject with a Level component attached to it
                LevelScriptableObject levelScriptable = ScriptableObject.CreateInstance<LevelScriptableObject>();
                levelScriptable.name = newLevelName;

                // Save the new LevelObject as an asset in the Levels folder
                AssetDatabase.CreateAsset(levelScriptable,
                    "Assets/Game/ScriptableObjects/Levels/" + newLevelName + ".asset");
                AssetDatabase.SaveAssets();

                // Add the new level to the list and select it
                ArrayUtility.Add(ref levelNames, newLevelName);
                selectedLevelIndex = levelNames.Length - 1;

                // Clear the new level name field
                newLevelName = "";
            }
        }

        GUILayout.Space(10f);

        GUILayout.Label("Existing Levels", EditorStyles.boldLabel);

        selectedLevelIndex = EditorGUILayout.Popup("Select Level", selectedLevelIndex, levelNames);


        if (GUILayout.Button("Open Level"))
        {
            // Get the selected level ScriptableObject
            LevelScriptableObject levelScriptableObject =
                AssetDatabase.LoadAssetAtPath<LevelScriptableObject>("Assets/Game/ScriptableObjects/Levels/" +
                                                                     levelNames[selectedLevelIndex] + ".asset");


            // Open the level in a new window
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