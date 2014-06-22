using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresentationScript : MonoBehaviour 
{
		
	private GestureListener gestureListener;

	private float turnSpeed = 250.0f;
	private float moveSpeed = 20f;

	private GameObject guiMsg;
	

	
	void Start() 
	{
		// hide mouse cursor
		Screen.showCursor = false;
		guiMsg = GameObject.Find("GestureMsg");
		// get the gestures listener
		gestureListener = Camera.main.GetComponent<GestureListener>();
		if (!gestureListener) {
			print("Gesture Listener not found");
		}
	}
	
	void Update() 
	{
		// dont run Update() if there is no user
		KinectManager kinectManager = KinectManager.Instance;
		if (!kinectManager || !kinectManager.IsInitialized () || !kinectManager.IsUserDetected ()) {
			print ("Kinect Manager is not initialized");
			return;
		}
		GameObject playerObject = GameObject.Find("ThePlayer");

		if (gestureListener.IsSwipeLeft ())
			RotateLeft (playerObject);
		else if (gestureListener.IsSwipeRight ())
			RotateRight (playerObject);
		else if (gestureListener.IsLeftHandRisen())
			Forward(playerObject);
		else if(gestureListener.IsRightHandRisen())
			Forward(playerObject);

					
	}

	private void Forward(GameObject playerObject )
	{
		playerObject.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Camera.main.transform);
	}

	private void Backward(GameObject playerObject )
	{
		playerObject.transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime, Camera.main.transform);
	}

	private void RotateLeft(GameObject playerObject )
	{
		playerObject.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
	}
	
	
	private void RotateRight(GameObject playerObject )
	{
		playerObject.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
	}
	
	
}
