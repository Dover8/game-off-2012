// Script that puts a window on-screen where the player can toggle who he controls
// It works by sending SetControllable messages to turn the different characters on and off.
// It also changes who the CameraScrolling scripts looks at.

// An internal reference to the attached CameraScrolling script
private var cameraScrolling : CameraScrolling;

// List of objects to control
var target : Transform;

// On start up, we send the SetControllable () message to turn the different players on and off.
function Awake () {

	// Get the reference to our CameraScrolling script attached to this camera;
	cameraScrolling = GetComponent (CameraScrolling);
	
	// Set the scrolling camera's target to be our character at the start.
	cameraScrolling.SetTarget (target, true);
	
}


// Ensure there is a CameraScrolling script attached to the same GameObject, as this script
// relies on it.
@script RequireComponent (CameraScrolling)
