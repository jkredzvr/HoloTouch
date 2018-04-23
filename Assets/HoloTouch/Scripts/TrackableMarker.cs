/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class TrackableMarker : MonoBehaviour, ITrackableEventHandler {
    #region PRIVATE_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    public GameObject debugGameObject;
    public GameObject renderGameObject;
    public TargetTrackingManager trackManager;
    public Color ActiveMat;
    public Color FoundMat;
    public Color ExtendedMat;
    public bool isDebugging;

    #endregion // PRIVATE_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    private void Awake() {
        if (trackManager != null) {
            trackManager.AddTracker(this);
        } else {
            Debug.Log("TrackManager not set");
        }
    }

    protected virtual void Start() {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        
       
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus) {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED) {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        } else if (newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " extended tracking");
            OnExtendedTracking();
        } else if (((previousStatus == TrackableBehaviour.Status.TRACKED) || (previousStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)) &&
                     newStatus == TrackableBehaviour.Status.NOT_FOUND) {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        } else {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    public void DebugMode(bool state) {
        if(!state)
            ShowDebugGameObject(false,ExtendedMat);
        isDebugging = state;
    }

    public TrackableBehaviour.Status GetTrackableState() {
        return mTrackableBehaviour.CurrentStatus;
    }

    public void ShowRenderGameObject(bool state) {
        var renderer = renderGameObject.GetComponentsInChildren<Renderer>(true);

        // Enable rendering:
        foreach (var component in renderer)
            component.enabled = state;

        ShowDebugGameObject(true, ActiveMat);

    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS

    protected virtual void OnTrackingFound() {
        if(isDebugging)
            ShowDebugGameObject(true, FoundMat );
        SignalTracked(true);   
    }

    protected virtual void OnExtendedTracking() {
        if (isDebugging)
            ShowDebugGameObject(true,ExtendedMat);
    }

    protected virtual void OnTrackingLost() {
        if (isDebugging)
            ShowDebugGameObject(false,ExtendedMat);
        SignalTracked(false);
    }

    private void ShowDebugGameObject(bool state, Color color) {
        var renderer = debugGameObject.GetComponentsInChildren<Renderer>(true);

        // Enable rendering:
        foreach (var component in renderer) {
            component.enabled = state;
            component.sharedMaterial.color = color;
        }  
    }

    private void SignalTracked(bool state) {
        trackManager.UpdateTrackState(this, state);
    }
    #endregion // PRIVATE_METHODS
}
