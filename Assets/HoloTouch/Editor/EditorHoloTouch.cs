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
        printModel = (GameObject)EditorGUI.ObjectField(new Rect(3, 3, position.width - 6, 20), "3D Model", printModel, typeof(GameObject));

        imgTarget1 = (GameObject)EditorGUI.ObjectField(new Rect(3, 23, position.width - 6, 20), "Image Target 1", imgTarget1, typeof(GameObject));
        imgTarget2 = (GameObject)EditorGUI.ObjectField(new Rect(3, 43, position.width - 6, 20), "Image Target 2", imgTarget2, typeof(GameObject));
        imgTarget3 = (GameObject)EditorGUI.ObjectField(new Rect(3, 63, position.width - 6, 20), "Image Target 3", imgTarget3, typeof(GameObject));
        imgTarget4 = (GameObject)EditorGUI.ObjectField(new Rect(3, 83, position.width - 6, 20), "Image Target 4", imgTarget4, typeof(GameObject));


        modelXDimension = EditorGUI.FloatField(new Rect(3, 103, position.width - 100, 20), "model x dimensions (m)", modelXDimension);
        modelYDimension = EditorGUI.FloatField(new Rect(3, 123, position.width - 100, 20), "model y dimensions (m)", modelYDimension);

        imgTargetXDimension = EditorGUI.FloatField(new Rect(3, 143, position.width - 100, 20), "image target x dimensions (m)", imgTargetXDimension);
        imgTargetYDimension = EditorGUI.FloatField(new Rect(3, 163, position.width - 100, 20), "image target y dimensions (m)", imgTargetYDimension);
   
        if (GUI.Button(new Rect(3, 200, position.width - 6, 20), "Apply Settings")) {
            ApplySettings();
        }
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
        imgTarget1.transform.localPosition = new Vector3(-xoffset, 0, yoffset);
        imgTarget2.transform.localPosition = new Vector3(xoffset, 0, yoffset);
        imgTarget3.transform.localPosition = new Vector3(-xoffset, 0, -yoffset);
        imgTarget4.transform.localPosition = new Vector3(xoffset, 0, -yoffset);
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
        GameObject model1 = CreateModel();
        model1.transform.SetParent(imgTarget1.transform.parent);
        model1.transform.localPosition = new Vector3(-(modelXDimension / 2.0f), 0, -(modelYDimension / 2.0f));
        model1.transform.SetParent(imgTarget1.transform);
        imgTarget1.GetComponent<TrackableMarker>().renderGameObject = model1; 

        GameObject model2 = CreateModel();
        model2.transform.SetParent(imgTarget2.transform.parent);
        model2.transform.localPosition = new Vector3(-(modelXDimension / 2.0f), 0, -(modelYDimension / 2.0f));
        model2.transform.SetParent(imgTarget2.transform);
        imgTarget2.GetComponent<TrackableMarker>().renderGameObject = model2;

        GameObject model3 = CreateModel();
        model3.transform.SetParent(imgTarget3.transform.parent);
        model3.transform.localPosition = new Vector3(-(modelXDimension / 2.0f), 0, -(modelYDimension / 2.0f));
        model3.transform.SetParent(imgTarget3.transform);
        imgTarget3.GetComponent<TrackableMarker>().renderGameObject = model3;

        GameObject model4 = CreateModel();
        model4.transform.SetParent(imgTarget4.transform.parent);
        model4.transform.localPosition = new Vector3(-(modelXDimension / 2.0f), 0, -(modelYDimension / 2.0f));
        model4.transform.SetParent(imgTarget4.transform);
        imgTarget4.GetComponent<TrackableMarker>().renderGameObject = model4;
    }
}