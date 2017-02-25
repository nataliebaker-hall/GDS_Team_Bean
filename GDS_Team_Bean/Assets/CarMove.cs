using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour 
{
	public float speed;
	public float sideBoundary;
	public float rotateAngle;
	Vector3 position;
	Quaternion rotation;
	float MaxSpeed;
	float vert;
	float horiz;

	// Use this for initialization
	void Start () 
	{
		MaxSpeed = 88.0f;
		position = transform.position;
		rotation = transform.rotation;
	}
	
	// Update is called once per frame
//	void Update()
//	{
//
//		speed += 0.02f;
//
//	}

	void Update () 
	{
		

		vert = Input.GetAxis ("Vertical");
		horiz = Input.GetAxis ("Horizontal");

		//only rotates on z axis
		transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z);

		//transform.gameObject.GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * speed * vert);

		position.x += horiz * speed * Time.deltaTime;
		transform.position = position;

		position.x = Mathf.Clamp (position.x, -sideBoundary, sideBoundary);
		//rotation.z = Mathf.Clamp (rotation.z, -30, 30);


		if(Input.GetButtonDown("Left"))// && horiz >= 0)
		{
			
			//if (horiz > 0 && transform.rotation.z < 30 && transform.rotation.z > 0) {
			//Debug.Log ("ButtonDownR");

			transform.Rotate(0, 0, -rotateAngle * Time.deltaTime);
		}
		else if (Input.GetButtonDown("Right"))// && horiz <= 0) 
		{
			//Debug.Log ("ButtonDownL");

			transform.Rotate(0, 0, rotateAngle  * Time.deltaTime );
		}

		if(Input.GetButtonUp("Horizontal"))
		{
			transform.rotation = new Quaternion (0, 0, 0,0);

			horiz = 0.0f;
			Debug.Log ("Button Up");
		}
	}

}