using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float input = Input.GetAxis ("Vertical");
		transform.gameObject.GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * speed * input);
	}
}
