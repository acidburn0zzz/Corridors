using UnityEngine;
using System.Collections;

public class PhotoScript : MonoBehaviour {
	public string path;
	private Object[] frames;
	private int framesPerSecond = 10;

	// Use this for initialization
	void Start () {
		frames = Resources.LoadAll(path);

		StartCoroutine(ChangeTheTexuture());
	}

	IEnumerator ChangeTheTexuture(){
		while (true) {
			yield return new WaitForSeconds (0.005f);
			changeTexture();
		}
	}

	public void Reload (){
		frames.Initialize ();
		frames = Resources.LoadAll(path);
	}

	void changeTexture()
	{
		int index = (int) (Time.time * framesPerSecond) % frames.Length;
		Texture theTexture = frames [index] as Texture;
		renderer.material.mainTexture = theTexture;
	}
	
}
