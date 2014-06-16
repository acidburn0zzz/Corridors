using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresentationScript : MonoBehaviour 
{
		
	private GestureListener gestureListener;
	

	
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
		if (gestureListener.IsSwipeLeft ())
			RotateLeft ();
		else if (gestureListener.IsSwipeRight ())
			RotateRight ();
		else if (gestureListener.IsSwipeUp())
			print ("up");
		else if(gestureListener.IsSwipeDown())
			print ("down");

					
	}
	
	
	private void RotateLeft()
	{
		print ("Rotate Left");
	}
	
	
	private void RotateRight()
	{
		print ("Rotate Right");
	}
	
	
}
