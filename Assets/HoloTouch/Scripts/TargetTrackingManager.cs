using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetTrackingManager : MonoBehaviour {
    public List<TrackableMarker> trackableMarkerList;

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

    private TrackableMarker GetTrackedMarker() {
        foreach (TrackableMarker trackable in trackableMarkerList) {  
            if ((trackable.GetTrackableState() == TrackableBehaviour.Status.DETECTED ||
            trackable.GetTrackableState() == TrackableBehaviour.Status.TRACKED)) {
                return trackable;
            }    
        }
        return null;
    }


    public void UpdateTrackState(TrackableMarker trackable, bool isTracked){
        if (!isTracked) {
            trackable.ShowRenderGameObject(false);
            
            //Show another Tracked Marker
            TrackableMarker anotherTrackedMarker = GetTrackedMarker();
            if (anotherTrackedMarker != null) {
                anotherTrackedMarker.ShowRenderGameObject(true);
            }
        } else {
            bool anyTrackedMarker = this.isTracked(trackable);
            if (!anyTrackedMarker) {
                Debug.Log("rendering graph");
                trackable.ShowRenderGameObject(true);
            }
        }
    }
}
