using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Hole))]
public class HoleMagnetRadiusViewer : Editor {
    private Hole hole;
    
    private void OnSceneGUI() {
        hole = target as Hole;
        
        Handles.color = Color.green;
        Handles.DrawWireDisc(hole.MagnetPoint, Vector3.up, hole.MagnetRange);

        Handles.color = Color.red;
        Handles.DrawWireDisc(hole.MagnetPoint, Vector3.up, hole.MagnetDeadZone);
    }
}
