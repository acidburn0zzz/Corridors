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
		if (collision.tag == "Player") {
			GameObject targetPlane = GameObject.Find(target);
			if (targetPlane != null)
			{
				GameObject playerObject = GameObject.Find("ThePlayer");
				playerObject.transform.position = targetPlane.transform.position;
				playerObject.transform.eulerAngles = new Vector3(0, 0, 0);
				//collision.transform.position = new Vector3(-4.02239f, -0.7922654f, 0.04430723f);
				SetAudio(playerObject, target);
			}else{
				print(target + "not found.");
			}
		}
	}

	private void SetAudio(GameObject playerObject, string targetCorridor)
	{
		Jukebox theJukebox = (Jukebox) playerObject.GetComponent(typeof(Jukebox));
		if (targetCorridor == "planeGang1"){
			theJukebox.SwitchMusic (Jukebox.Sound4Corridor.Gang1);
		}else if (targetCorridor == "planeGang2"){
			theJukebox.SwitchMusic (Jukebox.Sound4Corridor.Gang2);
		}else if (targetCorridor == "planeGang3"){
			theJukebox.SwitchMusic (Jukebox.Sound4Corridor.Gang3);
		}else if (targetCorridor == "planeGang4"){
			theJukebox.SwitchMusic (Jukebox.Sound4Corridor.Gang4);
		}else if (targetCorridor == "planeGang5"){
			theJukebox.SwitchMusic (Jukebox.Sound4Corridor.Gang5);
		}else{
			print ("Wrong arguments for changing the sound...");
		}
	}
}
