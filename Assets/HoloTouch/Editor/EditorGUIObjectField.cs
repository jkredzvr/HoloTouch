using UnityEditor;
using UnityEngine;
using System.Collections;

//Select the dependencies of the found GameObject
public class EditorGUIObjectField : EditorWindow {
    public GameObject obj = null;
    public GameObject model = null;
    public GameObject obj2 = null;
    public Vector3 scalingFactor;

    [Header("3D Printed Model Properties")]
    public GameObject printModel;
    public float modelXDimension;
    public float modelYDimension;

    [Header("Image Target Properties")]
    public float imgTargetXDimension;
    public float imgTargetYDimension;

    [MenuItem("HoloTouch/Settings")]
    static void Init() {
        UnityEditor.EditorWindow window = GetWindow(typeof(EditorGUIObjectField));
        window.position = new Rect(0, 0, 250, 80);
        window.Show();
    }

    void OnInspectorUpdate() {
        Repaint();
    }

    void OnGUI() {
        obj = (GameObject)EditorGUI.ObjectField(new Rect(3, 3, position.width - 6, 20), "Find Dependency", obj, typeof(GameObject));
        if (obj)
            if (GUI.Button(new Rect(3, 25, position.width - 6, 20), "Check Dependencies"))
                Selection.objects = EditorUtility.CollectDependencies(new GameObject[] { obj });
            else
                EditorGUI.LabelField(new Rect(3, 25, position.width - 6, 20), "Missing:", "Select an object first");

        model = (GameObject)EditorGUI.ObjectField(new Rect(3, 23, position.width - 6, 20), "Obj1", model, typeof(GameObject));
        obj2 = (GameObject)EditorGUI.ObjectField(new Rect(3, 43, position.width - 6, 20), "Obj2", obj2, typeof(GameObject));



        modelXDimension = EditorGUI.FloatField(new Rect(3, 63, position.width - 100, 20), "model x dimensions (m)", modelXDimension);
        modelYDimension = EditorGUI.FloatField(new Rect(3, 83, position.width - 100, 20), "model y dimensions (m)", modelYDimension);

        imgTargetXDimension = EditorGUI.FloatField(new Rect(3, 103, position.width - 100, 20), "image target x dimensions (m)", imgTargetXDimension);
        imgTargetYDimension = EditorGUI.FloatField(new Rect(3, 123, position.width - 100, 20), "image target y dimensions (m)", imgTargetYDimension);



        scalingFactor = EditorGUI.Vector3Field(new Rect(3, 143, position.width - 6, 20), "Scale Factor", scalingFactor);
   
        if (model & obj2)
            if (GUI.Button(new Rect(3, 183, position.width - 6, 20), "Apply Settings")) {
                ApplySettings();
                Selection.objects = EditorUtility.CollectDependencies(new GameObject[] { obj });
            }
            else
                EditorGUI.LabelField(new Rect(3, 25, position.width - 6, 20), "Missing:", "Select an object first");
    }

    public void ApplySettings() {
        model.name = "test1";
        obj2.name = "test2";

        obj2.transform.localScale = scalingFactor;
        obj2.transform.position = new Vector3(imgTargetXDimension, imgTargetYDimension, 0);
    }

}