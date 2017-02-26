using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("collide");
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
