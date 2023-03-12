using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FullScoreDisplayGenerator))]
public class FullScoreDisplayGeneratorInspector : Editor { // Have we gone too far?
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        FullScoreDisplayGenerator generator = target as FullScoreDisplayGenerator;
        
        if(GUILayout.Button("Generate Score Display Panel")) {
            generator.generatePanel();
        }
    }
}
