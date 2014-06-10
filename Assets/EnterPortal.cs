using UnityEngine;
using System.Collections;

public class EnterPortal : MonoBehaviour {

	public string target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnParticleCollision(GameObject collision) {
		print ("Collision detected");
		print (collision.tag);
		if (collision.tag == "Player") {
			GameObject targetPlane = GameObject.Find(target);
			if (targetPlane != null)
			{
				GameObject playerObject = GameObject.Find("ThePlayer");
				playerObject.transform.position = targetPlane.transform.position;
				//collision.transform.position = new Vector3(-4.02239f, -0.7922654f, 0.04430723f);
			}else{
				print(target + "not found.");
			}
		}
	}
}
