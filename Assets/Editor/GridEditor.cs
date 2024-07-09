using UnityEditor;
using UnityEngine;

public class GridEditor : EditorWindow
{
    private bool[,] grid = new bool[10, 10];
    private SerializedObject serializedObject;
    private SerializedProperty obstacleData;

    [MenuItem("Tools/Grid Editor")]
    public static void ShowWindow()
    {
        GetWindow<GridEditor>("Grid Editor");
    }

    void OnEnable()
    {
        serializedObject = new SerializedObject(ScriptableObject.CreateInstance<ObstacleData>());
        obstacleData = serializedObject.FindProperty("obstacles");
    }

    void OnGUI()
    {
        serializedObject.Update();
        GUILayout.Label("Toggle Obstacles", EditorStyles.boldLabel);

        for (int x = 0; x < 10; x++)
        {
            GUILayout.BeginHorizontal();
            for (int y = 0; y < 10; y++)
            {
                grid[x, y] = GUILayout.Toggle(grid[x, y], "");
            }
            GUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Save Obstacles"))
        {
            SaveObstacles();
        }

        serializedObject.ApplyModifiedProperties();
    }

    void SaveObstacles()
    {
        ObstacleData data = CreateInstance<ObstacleData>();
        data.obstacles = grid;
        AssetDatabase.CreateAsset(data, "Assets/ObstacleData.asset");
        AssetDatabase.SaveAssets();
    }
}
