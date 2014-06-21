using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {
	
	public float targetRotation = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GameObject theObject = GameObject.Find("ThePlayer");
		print (theObject.transform.rotation.y);
		if (targetRotation > theObject.transform.rotation.y) {
			float rotation = Time.deltaTime * 45f;
			theObject.transform.Rotate (0, rotation, 0, Space.Self);
		}
	}
}