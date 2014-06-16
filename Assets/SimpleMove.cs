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
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
			
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			//transform.Rotate(0, turnSpeed * Time.deltaTime, 0, Space.World);
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
		}
			//transform.RotateAround (, Vector3.up, turnSpeed * Time.d
    }
}
