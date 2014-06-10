using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour
{

    public float moveSpeed = 2.0f;
	public float turnSpeed = 20.0f;
	public float hoverForce = 2.0f;
    private Vector3 cameraDir;

    // Use this for initialization
    void Start()
    {
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
		//transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		//transform.rigidbody.AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//transform.RotateAround (Vector3.zero, Vector3.up, turnSpeed * Time.deltaTime);
			//transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime);
			//transform.Rotate(Vector3.right * Time.deltaTime);
			transform.RotateAround(transform.position, Vector3.up, turnSpeed * Time.deltaTime);
			//transform.RotateAround(renderer.bounds.center, new Vector3(1, -1, 0), turnSpeed);
			
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate(0, turnSpeed * Time.deltaTime, 0, Space.World);
		}
			//transform.RotateAround (, Vector3.up, turnSpeed * Time.deltaTime);
			//transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}
