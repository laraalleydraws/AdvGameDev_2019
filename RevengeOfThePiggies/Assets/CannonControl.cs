using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
	public Rigidbody2D piggyRB; // this is a reference to the player object
	public Camera mainCamera;
	Vector3 direction;

	const float STRENTH = 50; // the scalar that defines the STRENTH of the cannon
	const int MAX_ANGLE = 80;
	const int MIN_ANGLE = 5;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Vector3 mousePosition = new Vector3(Input.mousePosition.x,
			Input.mousePosition.y, -mainCamera.transform.position.z);

		Vector3 mousePositionInWorldCoordinates = mainCamera.ScreenToWorldPoint(mousePosition);
		direction = mousePositionInWorldCoordinates - transform.position;

		float alpha = Mathf.Acos(Vector3.Dot(Vector3.right, direction.normalized)) * Mathf.Rad2Deg;

		if (alpha < MAX_ANGLE && alpha > MIN_ANGLE && direction.y > 0)
		{
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, alpha));
		}

	}

	void FixedUpdate()
	{
		if (Input.GetButtonUp("Fire1"))
		{
			piggyRB.transform.parent = null;
			piggyRB.gravityScale = 1;
			piggyRB.AddForce(direction * STRENTH * piggyRB.mass);
		}
	}

	public void Run()
	{

	}
}
