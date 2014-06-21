using UnityEngine;
using System.Collections;

public class Portal_Beginning : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		print("Collision detected:"+col.gameObject.tag);
		if (col.gameObject.tag.Equals("Player"))
		{
			GameObject theObject = GameObject.Find("ThePlayer");
			theObject.transform.position = new Vector3(-5.0f, theObject.transform.position.y, theObject.transform.position.z);
		}
	}
	
}
