using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Fungus;
using UnityEngine.SceneManagement;
using System.IO;

public class FableCraftManager : MonoBehaviour
{
    [MenuItem("FableCraft/Create Scene")]
    public static void CreateNewScene()
    {
        ClearScenesInBuildIndex();

        List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
        List<string> SceneList = new List<string>();
        string MainFolder = "Assets/Scenes";

        DirectoryInfo d = new DirectoryInfo(@MainFolder);
        FileInfo[] Files = d.GetFiles("*.unity"); //Getting unity files

        foreach (FileInfo file in Files)
        {
            SceneList.Add(file.Name);
        }

        var buildIndexCount = SceneManager.sceneCountInBuildSettings;
        AssetDatabase.CopyAsset("Assets/Resources/Template/SampleScene.unity", $"Assets/Scenes/Scene{SceneList.Count}.unity");
        FableCraftManager.AddScenesToBuildIndex();
    }

    [MenuItem("FableCraft/Create Flow")]
    public static void CreateFableFlow()
    {
        GameObject go = new GameObject();
        go.AddComponent<Flowchart>();
        go.name = "New Flowchart";
    }

    [MenuItem("FableCraft/Add Scenes in Build Index")]
    public static void AddScenesToBuildIndex()
    {
        List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
        List<string> SceneList = new List<string>();
        string MainFolder = "Assets/Scenes";

        DirectoryInfo d = new DirectoryInfo(@MainFolder);
        FileInfo[] Files = d.GetFiles("*.unity"); //Getting unity files

        foreach (FileInfo file in Files)
        {
            Debug.Log("file name:" + file.Name);
            SceneList.Add(file.Name);
        }

        int i = 0;

        for (i = 0; i < SceneList.Count; i++)
        {
            string scenePath = MainFolder + "/" + SceneList[i];
            Debug.Log("i = " + i);
            Debug.Log("scene path:" + scenePath);
            editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(scenePath, true));
        }

        EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
    }

    [MenuItem("FableCraft/Clear Scenes in Build Index")]
    public static void ClearScenesInBuildIndex()
    {
        List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
        List<string> SceneList = new List<string>();
        string MainFolder = "Assets/Scenes";

        DirectoryInfo d = new DirectoryInfo(@MainFolder);
        FileInfo[] Files = d.GetFiles("*.unity"); //Getting unity files

        foreach (FileInfo file in Files)
        {
            Debug.Log("file name:" + file.Name);
            SceneList.Add(file.Name);
        }

        int i = 0;

        for (i = 0; i < SceneList.Count; i++)
        {
            string scenePath = MainFolder + "/" + SceneList[i];
            Debug.Log("i = " + i);
            Debug.Log("scene path:" + scenePath);
            editorBuildSettingsScenes.Clear();


        }

        EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
    }

    [MenuItem("FableCraft/Find Main Flowchart")]
    public static void FindMainFlowchart()
    {
        GameObject go = GameObject.FindGameObjectWithTag("MainFlowchart");
        Selection.activeObject = go;
    }
}
