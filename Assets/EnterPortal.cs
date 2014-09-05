using UnityEngine;
using System.Collections;

public class EnterPortal : MonoBehaviour {

	public string target;

	private ArrayList gaenge = new ArrayList();

	private string aktuellePortalId = "planeGang1";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnParticleCollision(GameObject collision) {
		if (collision.tag == "Player") {
			print ("test");
			GameObject targetPlane = GameObject.Find(aktuellePortalId);
			if (targetPlane != null)
			{
				GameObject playerObject = GameObject.Find("ThePlayer");
				playerObject.transform.position = targetPlane.transform.position;
				playerObject.transform.eulerAngles = new Vector3(0, 0, 0);
				//collision.transform.position = new Vector3(-4.02239f, -0.7922654f, 0.04430723f);
				SetAudioAndTextures(playerObject, target);
			}else{
				print(target + "not found.");
			}
		}
	}

	private void SetAudioAndTextures(GameObject playerObject, string targetCorridor)
	{
		Jukebox theJukebox = (Jukebox) playerObject.GetComponent(typeof(Jukebox));

		Gang naechsterGang = null;

		if (targetCorridor == "planeGang1"){
			naechsterGang = new Gang("planeGang1", "Gang1/Boden", "Gang1/Decke", "Gang1/Wand", "planeGang4", "planeGang4", "planeGang4", "planeGang4", Jukebox.Sound4Corridor.Gang1);
		}else if (targetCorridor == "planeGang2"){
			naechsterGang = new Gang("planeGang2", "Gang2/Boden", "Gang2/decke", "Gang2/wand", "1", "2", "3", "4", Jukebox.Sound4Corridor.Gang2);
		}else if (targetCorridor == "planeGang3"){
			naechsterGang = new Gang("planeGang3", "Gang3", "Gang3", "Gang3", "1", "2", "3", "4", Jukebox.Sound4Corridor.Gang3);
		}else if (targetCorridor == "planeGang4"){
			naechsterGang = new Gang("planeGang4", "Gang4", "Gang4", "Gang4", "Gang4", "planeGang1", "planeGang1", "planeGang1", Jukebox.Sound4Corridor.Gang4);
		}else if (targetCorridor == "planeGang5"){
			naechsterGang = new Gang("planeGang5", "Gang5", "Gang5", "Gang5", "1", "2", "3", "4", Jukebox.Sound4Corridor.Gang5);
		}else{
			print ("Wrong arguments for changing the sound...");
			return;
		}

		theJukebox.SwitchMusic (naechsterGang.sound);
		SetTextures (naechsterGang);
		SetPortals (naechsterGang);

		// umbenennen der Startfläche
		GameObject beginningPlane = GameObject.Find (aktuellePortalId);
		beginningPlane.name = naechsterGang.name;

		// setzen der aktuellen portalId
		aktuellePortalId = naechsterGang.name;
	}

	public void SetTextures(Gang corridor){
		GameObject[] boeden = GameObject.FindGameObjectsWithTag ("Boden");
		foreach (GameObject boden in boeden){
			PhotoScript other = (PhotoScript) boden.GetComponent(typeof(PhotoScript));
			other.path = corridor.boden;
			other.Reload();
		}

		GameObject[] waende = GameObject.FindGameObjectsWithTag ("Wand");
		foreach (GameObject wand in waende){
			PhotoScript other = (PhotoScript) wand.GetComponent(typeof(PhotoScript));
			other.path = corridor.wand;
			other.Reload();
		}

		GameObject[] decken = GameObject.FindGameObjectsWithTag ("Decke");
		foreach (GameObject decke in decken){
			PhotoScript other = (PhotoScript) decke.GetComponent(typeof(PhotoScript));
			other.path = corridor.decke;
			other.Reload();
		}
	}

	public void SetPortals(Gang corridor){
		GameObject[] startPortale = GameObject.FindGameObjectsWithTag ("PortStart");
		foreach (GameObject start in startPortale){
			EnterPortal other = (EnterPortal) start.GetComponent(typeof(EnterPortal));
			other.target = corridor.name;
		}
		GameObject[] port1Portale = GameObject.FindGameObjectsWithTag ("Port1");
		foreach (GameObject start in startPortale){
			EnterPortal other = (EnterPortal) start.GetComponent(typeof(EnterPortal));
			other.target = corridor.port1;
		}
		GameObject[] port2Portale = GameObject.FindGameObjectsWithTag ("Port2");
		foreach (GameObject start in startPortale){
			EnterPortal other = (EnterPortal) start.GetComponent(typeof(EnterPortal));
			other.target = corridor.port2;
		}
		GameObject[] port3Portale = GameObject.FindGameObjectsWithTag ("Port3");
		foreach (GameObject start in startPortale){
			EnterPortal other = (EnterPortal) start.GetComponent(typeof(EnterPortal));
			other.target = corridor.port3;
		}
		GameObject[] port4Portale = GameObject.FindGameObjectsWithTag ("Port4");
		foreach (GameObject start in startPortale){
			EnterPortal other = (EnterPortal) start.GetComponent(typeof(EnterPortal));
			other.target = corridor.port4;
		}

	}

	public class Gang {

		public string name { get; set; }
		public string boden { get; set; }
		public string decke { get; set; }
		public string wand { get; set; }

		public string port1 { get; set; }
		public string port2 { get; set; }
		public string port3 { get; set; }
		public string port4 { get; set; }

		public Jukebox.Sound4Corridor sound { get; set; }

		public Gang(string name, string boden, string decke, string wand, string port1, string port2, string port3, string port4, Jukebox.Sound4Corridor sound ){
			this.name = name;
			this.boden = boden;
			this.decke = decke;
			this.wand = wand;
			this.port1 = port1;
			this.port2 = port1;
			this.port3 = port1;
			this.port4 = port1;

			this.sound = sound;
		}
	}
}
