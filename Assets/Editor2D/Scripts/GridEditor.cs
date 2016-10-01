using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(Grid))]
public class GridEditor : Editor{

    Grid grid;

    public void OnEnable()
    {
        grid = (Grid)target;
    }

    public override void OnInspectorGUI()
    {

        grid.width= EditorGUILayout.FloatField("Grid Width", grid.width);

        grid.height = EditorGUILayout.FloatField("Grid Height", grid.height);

        grid.numColumns = EditorGUILayout.IntField("Number of Columns", grid.numColumns);

        grid.numRows = EditorGUILayout.IntField("Number of Rows", grid.numRows);

        SceneView.RepaintAll();
    }
}
