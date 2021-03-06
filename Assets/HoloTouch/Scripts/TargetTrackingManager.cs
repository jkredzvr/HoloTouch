﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetTrackingManager : MonoBehaviour {
    public TrackedModelScript model;
    public List<TrackableMarker> trackableMarkerList;
    public bool debugMode;

    private void Start() {
        foreach(TrackableMarker trackable in trackableMarkerList) {
            trackable.DebugMode(debugMode);
        }
    }

    public void AddTracker(TrackableMarker trackable) {
        trackableMarkerList.Add(trackable);
    }

    public bool isTracked(TrackableMarker updatedTrackable) {
        foreach (TrackableMarker trackable in trackableMarkerList) {
            if(updatedTrackable != trackable) {
                if ((trackable.GetTrackableState() == TrackableBehaviour.Status.DETECTED ||
                trackable.GetTrackableState() == TrackableBehaviour.Status.TRACKED)) {
                    return true;
                }
            } 
        }
        return false;
    }

    public TrackableMarker GetTrackedMarker() {
        foreach (TrackableMarker trackable in trackableMarkerList) {  
            if ((trackable.GetTrackableState() == TrackableBehaviour.Status.DETECTED ||
            trackable.GetTrackableState() == TrackableBehaviour.Status.TRACKED)) {
                return trackable;
            }    
        }
        return null;
    }

    public virtual void UpdateTrackState(TrackableMarker trackable, bool isTracked){
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
