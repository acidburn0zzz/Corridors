using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresentationScript : MonoBehaviour 
{
		
	private GestureListener gestureListener;

	private float turnSpeed = 150.0f;
	private float moveSpeed = 0.4f;

	private GameObject guiMsg;

	private bool kinectVonHinten = true;
	

	
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
	
	private void UpdateOldOne() 
	{
		GameObject playerObject = GameObject.Find("ThePlayer");
		// dont run Update() if there is no user
		KinectManager kinectManager = KinectManager.Instance;
		if (!kinectManager || !kinectManager.IsInitialized () || !kinectManager.IsUserDetected ()) {
			print ("Kinect Manager is not initialized");
			Forward(playerObject);
			return;
		}

		if (gestureListener.IsSwipeLeft ())
			RotateLeft (playerObject);
		else if (gestureListener.IsSwipeRight ())
			RotateRight (playerObject);
		else if (gestureListener.IsLeftHandRisen())
			Forward(playerObject);
		else if(gestureListener.IsRightHandRisen())
			Forward(playerObject);

					
	}

	void Update() 
	{
		GameObject playerObject = GameObject.Find("ThePlayer");
		// dont run Update() if there is no user
		KinectManager kinectManager = KinectManager.Instance;
		if (!kinectManager || !kinectManager.IsInitialized () || !kinectManager.IsUserDetected ()) {
			print ("Kinect Manager is not initialized");
			Forward(playerObject);
			return;
		}
		
		//if (gestureListener.IsSwipeLeft ())
		//	RotateLeft (playerObject);
		//else if (gestureListener.IsSwipeRight ())
		//	RotateRight (playerObject);
		if (gestureListener.IsLeftHandRisen())
			if (!kinectVonHinten){
				RotateLeft (playerObject);
			}else{
				RotateRight (playerObject);
			}
		else if(gestureListener.IsRightHandRisen())
			if (!kinectVonHinten){
				RotateRight (playerObject)
			}else{
				RotateLeft (playerObject);
			}
		else {
			Forward(playerObject);
		}
		
		
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
