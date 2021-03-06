﻿#if UNITY_EDITOR
    using UnityEngine;
    using System.Collections;

    [ExecuteInEditMode]
    public class Grid : MonoBehaviour {

        public float width    = 32.0f;
        public float height   = 32.0f;
        public int numColumns = 20;
        public int numRows    = 20;

        public Vector3 InitialPosition 
        {
            get 
            {
                return transform.position;
            }
        }

        void OnDrawGizmos()
        {
            Vector3 pos = InitialPosition;

            float halfCanvasWidth = (numColumns * width)/2;
            float halfCanvasHeight = (numRows * height)/2;

            // Draw Horizontal lines
            for (float y = pos.y - halfCanvasHeight; y <= pos.y + halfCanvasHeight; y += height)
            {
                Gizmos.DrawLine(new Vector3(-halfCanvasWidth + pos.x, (y / height) * height, 0.0f),
                                new Vector3(halfCanvasWidth + pos.x, (y / height) * height, 0.0f));
            }
            
            // Draw Vertical lines
            for (float x = pos.x - halfCanvasWidth; x <= pos.x + halfCanvasWidth; x += width)
            {
                Gizmos.DrawLine(new Vector3((x / width) * width, -halfCanvasHeight + pos.y, 0.0f),
                                new Vector3((x / width) * width, halfCanvasHeight + pos.y, 0.0f));
            }
        }
    }
#endif
