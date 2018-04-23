using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


/// <summary>
/// Target Tracking Manager that uses only one instance of 3D model
/// </summary>
public class TargetTrackingManager_Single : TargetTrackingManager {
    public TrackedModel model;

    public override void UpdateTrackState(TrackableMarker trackable, bool isTracked){
        if (!isTracked) {            
            //Show another Tracked Marker
            TrackableMarker anotherTrackedMarker = GetTrackedMarker();
            if (anotherTrackedMarker != null) {
                model.SetTarget(anotherTrackedMarker.gameObject);
                model.SetTrackTarget();
            } else {
                model.SetTarget(null);
            }
        } else {
            bool anyOtherTrackedMarkers = this.isTracked(trackable);
            if (!anyOtherTrackedMarkers) {
                model.SetTarget(trackable.gameObject);
                model.SetTrackTarget();
            }
        }
    }
}
