using UnityEngine;
using UnityEditor;
using System.IO;

public class UnityPackageImporter : EditorWindow
{
    private string directoryPath = string.Empty;

    [MenuItem("Tools/UnityPackage Importer")]
    public static void ShowWindow()
    {
        GetWindow<UnityPackageImporter>("UnityPackage Importer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Import All UnityPackages from a Directory", EditorStyles.boldLabel);

        directoryPath = EditorGUILayout.TextField("Directory Path:", directoryPath);

        if (GUILayout.Button("Select Directory"))
        {
            directoryPath = EditorUtility.OpenFolderPanel("Choose Directory", "", "");
        }

        if (GUILayout.Button("Import UnityPackages"))
        {
            ImportAllUnityPackagesFromDirectory(directoryPath);
        }
    }

    private void ImportAllUnityPackagesFromDirectory(string directory)
    {
        if (string.IsNullOrEmpty(directory))
        {
            Debug.LogWarning("Directory path is empty or null. Please specify a valid directory.");
            return;
        }

        string[] unityPackages = Directory.GetFiles(directory, "*.unitypackage");
        foreach (var package in unityPackages)
        {
            AssetDatabase.ImportPackage(package, false);
        }
    }
}
