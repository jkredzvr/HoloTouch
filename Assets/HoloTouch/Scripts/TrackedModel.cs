using UnityEngine;

public class TrackedModel : MonoBehaviour {

    private GameObject target;
    private bool isTracking = false;
    public float imgXDimension;
    public float imgYDimension;
    public float modelXDimension;
    public float modelYDimension;
    private Vector3 setRotation;

    // Use this for initialization
    void Awake () {
        setRotation = this.transform.rotation.eulerAngles;
    }

    public void SetTarget(GameObject obj) {
        target = obj;
    }

    public void SetTrackingState(bool state) {
        isTracking = state;
    }

    public void TrackTarget() {
        this.transform.rotation = target.transform.rotation;
        this.transform.position = target.transform.position + GetOffset();
    }

    public void SetTrackTarget() {
        this.transform.SetParent(target.transform);
        this.transform.localEulerAngles=(setRotation);
        this.transform.localPosition = GetOffset();
    }

    public Vector3 GetOffset() {
        switch (target.gameObject.name) {
            case "imgTarget1":
                return new Vector3((imgXDimension / 2.0f)/imgXDimension, 0, -(imgYDimension / 2.0f)/ imgYDimension - modelYDimension/imgYDimension);
            case "imgTarget2":
                return new Vector3(-(imgXDimension / 2.0f) / imgXDimension -modelXDimension / imgXDimension, 0, -(imgYDimension / 2.0f) / imgYDimension - modelYDimension / imgYDimension);
            case "imgTarget3":
                return new Vector3((imgXDimension / 2.0f) / imgXDimension, 0, (imgYDimension / 2.0f) / imgYDimension);
            case "imgTarget4":
                return new Vector3(-(imgXDimension / 2.0f) / imgXDimension - modelXDimension / imgXDimension, 0, (imgYDimension / 2.0f) / imgYDimension);
            default:
                return new Vector3(0, 0, 0);
        }      
    }
	
}
