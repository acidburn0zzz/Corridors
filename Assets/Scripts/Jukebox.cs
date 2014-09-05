using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jukebox : MonoBehaviour {

	public List<AudioClip> myList = new List<AudioClip>();

	public enum Sound4Corridor
	{
		Gang1,
		Gang2,
		Gang3,
		Gang4,
		Gang5,
		Gang6,
		Gang7
	}

	// Use this for initialization
	void Start () {
		myList.Add (Resources.Load("Music/Stimmung 01") as AudioClip);
		myList.Add (Resources.Load("Music/Stimmung 02") as AudioClip);
		myList.Add (Resources.Load("Music/Stimmung 03") as AudioClip);
		myList.Add (Resources.Load("Music/Stimmung 04") as AudioClip);
		myList.Add (Resources.Load("Music/Stimmung 05") as AudioClip);

		audio.loop = true;
		// Set Music at beginning
		SwitchMusic (Sound4Corridor.Gang1);
	}

	public void SwitchMusic(Sound4Corridor corridor)
	{
		AudioClip clipToPlay = null;
		print ("Switching to " + corridor.ToString ());
		switch (corridor) {
		case Sound4Corridor.Gang1:
			clipToPlay = myList[0];
			break;
		case Sound4Corridor.Gang2:
			clipToPlay = myList[1];
			break;
		case Sound4Corridor.Gang3:
			clipToPlay = myList[2];
			break;
		case Sound4Corridor.Gang4:
			clipToPlay = myList[3];
			break;
		case Sound4Corridor.Gang5:
			clipToPlay = myList[4];
			break;
		default:
			break;
		}
		if (clipToPlay == null) {
			print ("Soundfile not found" + corridor.ToString());
			return;
		}
		if (audio.isPlaying)
			audio.Stop();

		audio.loop = true;
		audio.clip = clipToPlay;
		//audio.PlayOneShot (clipToPlay, 1.0F);
		audio.Play();
	}
	
}
