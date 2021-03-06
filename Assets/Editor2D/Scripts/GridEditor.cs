﻿using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(Grid))]
public class GridEditor : Editor{

    Grid grid;

    public void OnEnable()
    {
        grid = (Grid)target;
        SceneView.onSceneGUIDelegate = GridUpdate;
    }

    private void GridUpdate(SceneView sceneView)
    {
        Event e = Event.current;
        Ray r = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
        Vector3 mousePos = r.origin;

        // Right Click
        if (e.isMouse && e.button == 1 && e.type == EventType.MouseDown)
        {
            GameObject obj;
            Object prefab = PrefabUtility.GetPrefabParent(Selection.activeObject);

            if (prefab && isOnGrid(mousePos))
            {
                obj = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                Vector3 aligned = new Vector3( Mathf.Floor(mousePos.x/grid.width)  * grid.width + grid.InitialPosition.x + (grid.width/2),
                                               Mathf.Floor(mousePos.y / grid.height) * grid.height + grid.InitialPosition.y + (grid.height / 2), 0);
                obj.transform.position = aligned;
            }
        }
    }

    private bool isOnGrid(Vector3 mousePos)
    {
        return mousePos.x < ((grid.numColumns * grid.width) / 2) + grid.InitialPosition.x && mousePos.x > -((grid.numColumns * grid.width) / 2) + grid.InitialPosition.x
               &&
               mousePos.y < ((grid.numRows * grid.height) / 2) + grid.InitialPosition.y && mousePos.y > -((grid.numRows * grid.height) / 2) + grid.InitialPosition.y;             
    }

    public override void OnInspectorGUI()
    {
        grid.width           = EditorGUILayout.FloatField("Grid Width", grid.width);
        grid.height          = EditorGUILayout.FloatField("Grid Height", grid.height);
        grid.numColumns      = EditorGUILayout.IntField("Number of Columns", grid.numColumns);
        grid.numRows         = EditorGUILayout.IntField("Number of Rows", grid.numRows);

        SceneView.RepaintAll();
    }
}
