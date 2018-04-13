using UnityEngine;
using System.Collections;
using System;


[Serializable]
[CreateAssetMenu(menuName = "HoloTouchSettings")]
public class HoloTouchSettings : ScriptableObject {

    public GameObject obj1;
    public GameObject obj2;
    public Vector3 v3;


    [Header("3D Printed Model Properties")]
    public GameObject printModel;
    public float modelXDimension;
    public float modelYDimension;

    [Header("Image Target Properties")]
    public float imgTargetXDimension;
    public float imgTargetYDimension;


    public void ApplySettings() {
        obj1.transform.position = obj2.transform.position + v3;
        obj2.gameObject.name = "test1";
    }
}