using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SyncPaths))]
public class SyncPathsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        SyncPaths paths = (SyncPaths)target;

        if (GUILayout.Button("Sync Paths"))
        {
            paths.SynchronizePaths();
            SceneView.RepaintAll();
        }

        if(GUILayout.Button("Assign PlayerStats"))
        {
            paths.SyncPlayerStats();
        }

    }
}
