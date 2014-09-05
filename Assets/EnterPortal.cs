using UnityEngine;
using System.Collections;

public class EnterPortal : MonoBehaviour {

	public string target;

	private ArrayList gaenge = new ArrayList();

	public string aktuellePortalId = "planeGang1";

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
		Debug.Break ();
		Gang naechsterGang = null;

		if (targetCorridor == "planeGang1"){
			naechsterGang = new Gang("planeGang1", Jukebox.Sound4Corridor.Gang1);

			// Textures
			naechsterGang.boden = "Gang1/Boden";
			naechsterGang.decke = "Gang1/Decke";
			naechsterGang.wand = "Gang1/Wand";

			// Portale
			naechsterGang.port1 = "planeGang4";
			naechsterGang.port2 = "planeGang4";
			naechsterGang.port3 = "planeGang4";
			naechsterGang.port4 = "planeGang4";
		}else if (targetCorridor == "planeGang2"){
			naechsterGang = new Gang("planeGang2", Jukebox.Sound4Corridor.Gang2);
			
			// Textures
			naechsterGang.boden = "Gang2/Boden";
			naechsterGang.decke = "Gang2/decke";
			naechsterGang.wand = "Gang2/wand";
			
			// Portale
			naechsterGang.port1 = "Gang";
			naechsterGang.port2 = "planeGang4";
			naechsterGang.port3 = "planeGang4";
			naechsterGang.port4 = "planeGang4";
		}else if (targetCorridor == "planeGang3"){
			naechsterGang = new Gang("planeGang3", Jukebox.Sound4Corridor.Gang3);
			
			// Textures
			naechsterGang.boden = "Gang3";
			naechsterGang.decke = "Gang3";
			naechsterGang.wand = "Gang3";
			
			// Portale
			naechsterGang.port1 = "planeGang4";
			naechsterGang.port2 = "planeGang4";
			naechsterGang.port3 = "planeGang4";
			naechsterGang.port4 = "planeGang4";
		}else if (targetCorridor == "planeGang4"){
			naechsterGang = new Gang("planeGang4", Jukebox.Sound4Corridor.Gang4);
			
			// Textures
			naechsterGang.boden = "Gang4";
			naechsterGang.decke = "Gang4";
			naechsterGang.wand = "Gang4";
			
			// Portale
			naechsterGang.port1 = "planeGang4";
			naechsterGang.port2 = "planeGang4";
			naechsterGang.port3 = "planeGang4";
			naechsterGang.port4 = "planeGang4";
		}else if (targetCorridor == "planeGang5"){
			naechsterGang = new Gang("planeGang5", Jukebox.Sound4Corridor.Gang5);
			
			// Textures
			naechsterGang.boden = "Gang5";
			naechsterGang.decke = "Gang5";
			naechsterGang.wand = "Gang5";
			
			// Portale
			naechsterGang.port1 = "planeGang4";
			naechsterGang.port2 = "planeGang4";
			naechsterGang.port3 = "planeGang4";
			naechsterGang.port4 = "planeGang4";
		}else if (targetCorridor == "planeGang6"){
			naechsterGang = new Gang("planeGang6", Jukebox.Sound4Corridor.Gang6);
			
			// Textures
			naechsterGang.boden = "Gang6";
			naechsterGang.decke = "Gang6";
			naechsterGang.wand = "Gang6";
			
			// Portale
			naechsterGang.port1 = "planeGang4";
			naechsterGang.port2 = "planeGang4";
			naechsterGang.port3 = "planeGang4";
			naechsterGang.port4 = "planeGang4";
		}else if (targetCorridor == "planeGang7"){
			naechsterGang = new Gang("planeGang7", Jukebox.Sound4Corridor.Gang7);
			
			// Textures
			naechsterGang.boden = "Gang7";
			naechsterGang.decke = "Gang7";
			naechsterGang.wand = "Gang7";
			
			// Portale
			naechsterGang.port1 = "planeGang4";
			naechsterGang.port2 = "planeGang4";
			naechsterGang.port3 = "planeGang4";
			naechsterGang.port4 = "planeGang4";
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
			SetTextureAndReload(boden, corridor.boden);
		}

		GameObject[] waende = GameObject.FindGameObjectsWithTag ("Wand");
		foreach (GameObject wand in waende){
			SetTextureAndReload(wand, corridor.wand);
		}

		GameObject[] decken = GameObject.FindGameObjectsWithTag ("Decke");
		foreach (GameObject decke in decken){
			SetTextureAndReload(decke, corridor.decke);
		}
	}

	private void SetTextureAndReload(GameObject theObject, string path){
		if (theObject.GetComponent(typeof(PhotoScript)) != null){
			PhotoScript deckeScript = (PhotoScript) theObject.GetComponent(typeof(PhotoScript));
			deckeScript.path = path;
			deckeScript.Reload();
		}
	}

	public void SetPortals(Gang corridor){
		GameObject[] startPortale = GameObject.FindGameObjectsWithTag ("PortStart");
		foreach (GameObject start in startPortale){
			EnterPortal other = (EnterPortal) start.GetComponent(typeof(EnterPortal));
			other.target = corridor.name;
			other.aktuellePortalId = corridor.name;
		}
		GameObject[] port1Portale = GameObject.FindGameObjectsWithTag ("Port1");
		foreach (GameObject start in startPortale){
			EnterPortal other = (EnterPortal) start.GetComponent(typeof(EnterPortal));
			other.target = corridor.port1;
			other.aktuellePortalId = corridor.name;
		}
		GameObject[] port2Portale = GameObject.FindGameObjectsWithTag ("Port2");
		foreach (GameObject start in startPortale){
			EnterPortal other = (EnterPortal) start.GetComponent(typeof(EnterPortal));
			other.target = corridor.port2;
			other.aktuellePortalId = corridor.name;
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
			other.aktuellePortalId = corridor.name;
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

		public Gang(string name, Jukebox.Sound4Corridor sound ){
			this.name = name;
			this.sound = sound;
		}
	}
}
