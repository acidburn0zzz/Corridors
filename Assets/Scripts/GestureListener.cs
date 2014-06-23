using UnityEngine;
using System.Collections;
using System;

public class GestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	// GUI Text to display the gesture messages.
	//public GUIText GestureInfo;
	
	private bool swipeLeft;
	private bool swipeRight;
	private bool riseLeftHand;
	private bool riseRightHand;
	
	public bool IsSwipeLeft()
	{
		if(swipeLeft)
		{
			swipeLeft = false;
			return true;
		}
		
		return false;
	}
	
	public bool IsSwipeRight()
	{
		if(swipeRight)
		{
			swipeRight = false;
			return true;
		}
		
		return false;
	}
	
	public bool IsRightHandRisen()
	{
		if(riseRightHand)
		{
			riseRightHand = false;
			return true;
		}
		
		return false;
	}
	
	public bool IsLeftHandRisen()
	{
		if(riseLeftHand)
		{
			riseLeftHand = false;
			return true;
		}
		
		return false;
	}
	

	public void UserDetected(uint userId, int userIndex)
	{
		print ("User.Detected");
		// detect these user specific gestures
		KinectManager manager = KinectManager.Instance;
		
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);
		//manager.DetectGesture(userId, KinectGestures.Gestures.SwipeUp);
		//manager.DetectGesture(userId, KinectGestures.Gestures.SwipeDown);
		manager.DetectGesture(userId, KinectGestures.Gestures.RaiseRightHand);
		manager.DetectGesture(userId, KinectGestures.Gestures.RaiseLeftHand);
	}
	
	public void UserLost(uint userId, int userIndex)
	{
		print ("User.Lost");
	}

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, 
		float progress, KinectWrapper.SkeletonJoint joint, Vector3 screenPos)
	{
		// don't do anything here
	}

	public bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
		KinectWrapper.SkeletonJoint joint, Vector3 screenPos)
	{
		string sGestureText = gesture + " detected";
	
		print (sGestureText);

		
		if (gesture == KinectGestures.Gestures.SwipeLeft){
			swipeLeft = true;
		}else if (gesture == KinectGestures.Gestures.SwipeRight){
			swipeRight = true;
		//else if (gesture == KinectGestures.Gestures.SwipeUp)
		//	swipeUp = true;
		//else if (gesture == KinectGestures.Gestures.SwipeDown)
		//	swipeDown = true;
		}else if (gesture == KinectGestures.Gestures.RaiseLeftHand){
			riseLeftHand = true;
		}else if (gesture == KinectGestures.Gestures.RaiseRightHand){
			riseRightHand = true;
		}
		return true;
	}

	public bool GestureCancelled (uint userId, int userIndex, KinectGestures.Gestures gesture, 
		KinectWrapper.SkeletonJoint joint)
	{
		// don't do anything here, just reset the gesture state
		return true;
	}
	
}
