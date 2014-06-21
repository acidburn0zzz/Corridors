using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresentationScript : MonoBehaviour 
{
		
	private GestureListener gestureListener;

	private float turnSpeed = 150.0f;
	private float moveSpeed = 10f;
	

	
	void Start() 
	{
		// hide mouse cursor
		Screen.showCursor = false;
		
		// get the gestures listener
		gestureListener = Camera.main.GetComponent<GestureListener>();
		if (gestureListener) {
			print("gestureListener initialized");
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
		else if (gestureListener.IsSwipeUp())
			Forward(playerObject);
		else if(gestureListener.IsSwipeDown())
			Backward(playerObject);

					
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
