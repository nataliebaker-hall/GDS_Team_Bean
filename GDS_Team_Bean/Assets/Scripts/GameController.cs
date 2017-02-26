using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public GameObject car;
	public GameObject road;

	public GameObject[] all_obstacle;
	public GameObject ob_prefab;
	Obstacle ob_prefab_script;

	//GameObject spawned_ob_holder;

	bool spawned_cone;

	float spawn_x;
	float spawn_counter;
	public float spawn_wait = 2;
	public float spawn_wait_cones = 2;

	public float speed = 2;
	float obstacle_speed = 2;
	//float move_amount;

	Vector2 movement;

	GameObject[] road_array;
	public float[] spawn_locations;
	//ArrayList obstacles;
	List<GameObject> obstacles;
	List<GameObject> obstacles_remove;

	int num;

	// Use this for initialization
	void Start () 
	{
		spawned_cone = false;
		num = 0;
		spawn_x = 0.0f;

		spawn_counter = 0.0f;
		obstacle_speed = speed * 0.9f;

		obstacles = new List<GameObject> ();
		obstacles_remove = new List<GameObject> ();

		road_array = new GameObject[2];
		road_array [0] = Instantiate (road, new Vector2 (0.0f, 0.0f), Quaternion.identity) as GameObject;
		road_array [1] = Instantiate (road, new Vector2 (0.0f, 32.4f), Quaternion.identity) as GameObject;

		 //= road_clone;



		movement = new Vector2 (0.0f, -1.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		road_array[0].transform.Translate (movement * Time.deltaTime * speed);
		road_array[1].transform.Translate (movement * Time.deltaTime * speed);

		if (road_array [0].transform.position.y < -32.5f) 
		{
			Destroy (road_array [0].gameObject);
			road_array [0] = road_array [1];
			road_array[1] = Instantiate (road, new Vector2 (0, 31.8f), Quaternion.identity) as GameObject;
		}

		if (spawn_counter > spawn_wait + spawn_wait_cones) 
		{
			num = Random.Range (0, 10);

			GameObject ob_prefab_clone;// = Instantiate(ob_prefab, new Vector2 (0.0f, 0.0f), Quaternion.identity) as GameObject;
			//ob_prefab_script = ob_prefab_clone.GetComponent<Obstacle> ();

			if (num == 9) 
			{
				ob_prefab_clone = Instantiate(all_obstacle [1], new Vector3 (spawn_locations [0] - 2.7f, 30.0f, -2.0f), Quaternion.identity) as GameObject;

				ob_prefab_script = ob_prefab_clone.GetComponent<Obstacle> ();
				ob_prefab_script.cone_thing = true;
				spawn_wait_cones = spawn_wait;

				ob_prefab_script.obstacle_speed = speed;
			} 
			else if (num > 5) 
			{

				ob_prefab_clone = Instantiate(all_obstacle [2], new Vector3 (spawn_locations [Random.Range (0, 3)], 20.0f, -2.0f), Quaternion.identity) as GameObject;

				ob_prefab_script = ob_prefab_clone.GetComponent<Obstacle> ();
				ob_prefab_script.cone_thing = false;
				spawn_wait_cones = 0.0f;

				ob_prefab_script.obstacle_speed = speed * Random.Range(0.5f, 0.9f);
			} 
			else 
			{
				ob_prefab_clone = Instantiate(all_obstacle [0], new Vector3 (spawn_locations [Random.Range (0, 3)], 20.0f, -2.0f), Quaternion.identity) as GameObject;

				ob_prefab_script = ob_prefab_clone.GetComponent<Obstacle> ();

				ob_prefab_script.cone_thing = false;
				spawn_wait_cones = 0.0f;

				ob_prefab_script.obstacle_speed = speed *  Random.Range(0.5f, 0.9f);
			}

			//ob_prefab_script.obstacle_speed = speed;

//			if (spawned_cone == true) 
//			{
//				spawn_x = spawn_locations [Random.Range (0, 3)] - 2.7f;
//			} 
//			else 
//			{
//				spawn_x = spawn_locations [Random.Range (0, 3)];
//			}

			//ob_prefab_script.Spawn (spawn_locations [Random.Range (0, 3)], 20.0f);


			obstacles.Add (ob_prefab_clone);

			//obstacles.Add(Instantiate (spawned_ob, new Vector3 (spawn_x, 20.0f, -2.0f), Quaternion.identity) as GameObject);
			spawn_counter = 0.0f;
			spawn_wait = Random.Range (1.0f / (speed / 10.0f), 4.0f / (speed / 10.0f));
		}

		foreach(GameObject i in obstacles)
		{

			ob_prefab_script = i.GetComponent<Obstacle> ();
			ob_prefab_script.UpdateMovement ();
			//i.transform.Translate (movement * Time.deltaTime * obstacle_speed);

			//if (ob_prefab_script.obst.transform.position.y < -30) 
			if (i.transform.position.y < -30)
			{
				obstacles_remove.Add(i);
			}
		}

		foreach (GameObject i in obstacles_remove) 
		{
			

			//Destroy (i);
			//Debug.Log ("Assigning Obstacle to Temp_Script");
			Obstacle temp_script = i.GetComponent<Obstacle>();
			//Debug.Log ("Got script");
			//Debug.Log ("Removing obstacle from obstacle list");
			obstacles.Remove (i);
			//Debug.Log ("Destroying temp_script");
			temp_script.KillMe = true;
			//Destroy (temp_script);
			//Debug.Log ("Destroying i");

			Destroy (i);



			//temp_script.KillSelf();
		}
		obstacles_remove.Clear ();

//		for (int i = 0; i < obstacles.Count; i++) 
//		{
//			
//			obstacles
//
//
//				.gametransform.Translate (movement * Time.deltaTime * speed);
//		}

		spawn_counter += Time.deltaTime;
		speed += Time.deltaTime * 0.5f;

	
	}
}
