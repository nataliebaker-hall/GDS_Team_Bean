using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour 
{

	//public GameObject obst;
	public bool cone_thing;
	public float obstacle_speed;
	public bool KillMe = false;
	Vector2 movement;

	// Use this for initialization
	void Start () 
	{
		movement = new Vector2 (0.0f, -1.0f);
	}

	public void KillSelf()
	{
		//Destroy (obst);
		Destroy (this.gameObject);
	}

	public void UpdateMovement()
	{
		//Debug.Log (obst.name);
		//this.transform.Translate (Time.deltaTime * obstacle_speed);
		this.transform.Translate(new Vector2 (0.0f, -1.0f) * Time.deltaTime * obstacle_speed);
	}

//	public void Spawn(float x, float y)
//	{
//		if (cone_thing == true) 
//		{
//			
//			obst = Instantiate (obst, new Vector3 (x - 2.7f, y, -2.0f), Quaternion.identity) as GameObject;
//		} 
//		else 
//		{
//			obst = Instantiate (obst, new Vector3 (x, y, -2.0f), Quaternion.identity) as GameObject;
//		}
//	}

	// Update is called once per frame
	void Update () 
	{
		if (KillMe == true)
			KillSelf();
	}
}
