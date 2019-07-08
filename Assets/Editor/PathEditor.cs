using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Path customPath = (Path)target;
        if (customPath._drawGizmos)
        {
            DrawButton(customPath, "Hide");
        }
        else
        {
            DrawButton(customPath, "Show");
        }
        
    }

    private void DrawButton(Path customPath, string buttonText)
    {
        if (GUILayout.Button(buttonText))
        {
            customPath._drawGizmos = !customPath._drawGizmos;
            SceneView.RepaintAll();
        }
    }
}
