using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour
{

    public float moveSpeed = 2.0f;
	public float turnSpeed = 20.0f;
	public float hoverForce = 2.0f;
    private Vector3 cameraDir;

	private Vector3 curEuler;

	private bool rotating = true;

    // Use this for initialization
    void Start()
    {
		GameObject playerObject = GameObject.Find("ThePlayer");
		curEuler = playerObject.transform.eulerAngles;
    }

	void Update()
	{

	}

    void FixedUpdate()
    {
		if (Input.GetKey (KeyCode.UpArrow)) {
			//transform.position = new Vector3 (transform.position.x - 0.09f, transform.position.y, transform.position.z);
			transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Camera.main.transform);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
			RotateAngle(90);

		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			//transform.Rotate(0, turnSpeed * Time.deltaTime, 0, Space.World);
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
		}
			//transform.RotateAround (, Vector3.up, turnSpeed * Time.d
    }

	void RotateAngle(float angle){
		if (rotating) return; // ignore calls to RotateAngle while rotating
		rotating = true; // set the flag
		var newAngle = transform.eulerAngles.y+angle; // calculate the new angle
		while (curEuler.y < newAngle){
			// move a little step at constant speed to the new angle:
			curEuler.y = Mathf.MoveTowards(curEuler.y, newAngle, 90.0f*Time.deltaTime);
			transform.eulerAngles = curEuler; // update the object's rotation...
			 // and let Unity free till the next fra
		}
		rotating = false;
	}
}
