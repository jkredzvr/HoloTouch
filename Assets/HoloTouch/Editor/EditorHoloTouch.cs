using UnityEditor;
using UnityEngine;
using System.Collections;

/// <summary>
/// Editor for HoloTouch settings
/// </summary>
public class EditorHoloTouch : EditorWindow {
    public GameObject printModel = null;

    public GameObject imgTarget1 = null;
    public GameObject imgTarget2 = null;
    public GameObject imgTarget3 = null;
    public GameObject imgTarget4 = null;

    public GameObject targetPlacementManger = null;
    
    public float modelXDimension;
    public float modelYDimension;
    
    public float imgTargetXDimension;
    public float imgTargetYDimension;

    private float xoffset;
    private float yoffset;

    [MenuItem("HoloTouch/Settings")]
    static void Init() {
        UnityEditor.EditorWindow window = GetWindow(typeof(EditorHoloTouch));
        window.position = new Rect(0, 0, 500, 300);
        window.Show();
    }

    void OnInspectorUpdate() {
        Repaint();
    }

    //Editor Rendering
    void OnGUI() {
        EditorGUILayout.LabelField(new GUIContent("3D Model Info", "Enter 3D Model dimensions for arranging model GameObject"), EditorStyles.boldLabel);
        printModel = (GameObject)EditorGUILayout.ObjectField(new GUIContent("3D Model", "Drag in the 3D model to be projected by the HoloLens.  Keep in mind that the Unity coordinate system uses Y axis in the Z direction."), printModel, typeof(GameObject), true);
        EditorGUILayout.Space();

        modelXDimension = EditorGUILayout.FloatField(new GUIContent("Model x dimensions (m)", "Enter the 3D model's width in meters"), modelXDimension);
        modelYDimension = EditorGUILayout.FloatField(new GUIContent("Model y dimensions (m)", "Enter the 3D model's length in meters"), modelYDimension);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField(new GUIContent("Target Manager", "Drag Target Manager GameObject"), EditorStyles.boldLabel);
        targetPlacementManger = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Target Manager", "Drag Target Manager GameObject."), targetPlacementManger, typeof(GameObject), true);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField(new GUIContent("Image Target Info", "Enter image target dimensions for arranging image target GameObjects"), EditorStyles.boldLabel);
        imgTarget1 = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Image Target 1", "Drag Image Target 1's GameObject"), imgTarget1, typeof(GameObject), true);
        imgTarget2 = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Image Target 2", "Drag Image Target 2's GameObject"), imgTarget2, typeof(GameObject), true);
        imgTarget3 = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Image Target 3", "Drag Image Target 3's GameObject"), imgTarget3, typeof(GameObject), true);
        imgTarget4 = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Image Target 4", "Drag Image Target 4's GameObject"), imgTarget4, typeof(GameObject), true);
        EditorGUILayout.Space();

        imgTargetXDimension = EditorGUILayout.FloatField(new GUIContent("Image target x dimensions(m)", "Enter the image targets width in meters"), imgTargetXDimension);
        imgTargetYDimension = EditorGUILayout.FloatField(new GUIContent("Image target y dimensions(m)", "Enter the image targets length in meters"), imgTargetYDimension);
        EditorGUILayout.Space();

        if (GUILayout.Button(new GUIContent("Apply Settings","Press to automatically set up the positioning of the image targets and 3D models."))) {
            ApplySettings();
        }
        EditorGUILayout.Space();
    }

    /// <summary>
    /// Applies the image target and 3D model dimensions to positioning of the GameObjects
    /// </summary>
    public void ApplySettings() {
        xoffset = (modelXDimension / 2.0f) + (imgTargetXDimension / 2.0f);
        yoffset = (modelYDimension / 2.0f) + (imgTargetYDimension / 2.0f);
        PositionImageTargets();
        PositionModels();
    }

    /// <summary>
    /// Position each image target to be at the corners of the 3D model
    /// </summary>
    public void PositionImageTargets() {
        Undo.RecordObjects(new GameObject[] { imgTarget1, imgTarget2, imgTarget3, imgTarget4 },"Postioning Image Targets");
        imgTarget1.transform.localPosition = new Vector3(-xoffset, 0, yoffset);
        imgTarget2.transform.localPosition = new Vector3(xoffset, 0, yoffset);
        imgTarget3.transform.localPosition = new Vector3(-xoffset, 0, -yoffset);
        imgTarget4.transform.localPosition = new Vector3(xoffset, 0, -yoffset);
        EditorUtility.SetDirty(imgTarget1);
        EditorUtility.SetDirty(imgTarget2);
        EditorUtility.SetDirty(imgTarget3);
        EditorUtility.SetDirty(imgTarget4);
    }

    /// <summary>
    /// Method for instantiating and returning the 3D Print model GameObject
    /// </summary>
    public GameObject CreateModel() {
        return Instantiate(printModel);
    }

    /// <summary>
    /// Creates a 3D Model for each image target to render, aligns each model so that each corner is touching an image target and the 3D model is in the center. Last step is parenting the 3D model as a child
    /// of one of the image targets.  That way when an image target is recognized by Vuforia, it will render its 3D model.
    /// </summary>
    public void PositionModels() {
        GameObject model = CreateModel();
        model.transform.SetParent(targetPlacementManger.transform);
        model.transform.localPosition = new Vector3(-(modelXDimension / 2.0f), 0, -(modelYDimension / 2.0f));

        TrackedModelScript trackedModel = model.AddComponent<TrackedModelScript>();
        trackedModel.modelXDimension = modelXDimension;
        trackedModel.modelYDimension = modelYDimension;
        trackedModel.imgXDimension = imgTargetXDimension;
        trackedModel.imgYDimension = imgTargetYDimension;
    }
}