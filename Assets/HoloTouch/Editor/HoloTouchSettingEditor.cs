using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(HoloTouchSettings))]
public class HoloTouchSettingsEditor : Editor {

    HoloTouchSettings comp;
    static bool showTileEditor = false;

    public void OnEnable() {
    }

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        HoloTouchSettings holotouchsetting = (HoloTouchSettings)target;
        if (GUILayout.Button("Apply Settings")) {
            holotouchsetting.ApplySettings();
        }
    }

}