using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPursue : MonoBehaviour{

	public GameObject Player;
	public GameObject Enemy;
	Vector3 desiredVelocity;
	float distance;
	Vector3 velocity = new Vector3(0, 0, 1);
	public float maxForce = 10.0f;
	public float topSpeed = 1.0f;
	public float mass = 2.0f;
	
	// Use this for initialization
	void Start () 
	{
		Player = GameObject.Find("Player");
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		distance = Vector3.Distance(Enemy.transform.position, Player.transform.position);
		
		if(Player != null && distance > 2.0)
		{
			seekTarget();
		}
		if(Player.transform.position.y > Enemy.transform.position.y)
		{
			Enemy.transform.position = new Vector3(Enemy.transform.position.x,1,Enemy.transform.position.z);
		}



	}

	void seekTarget()
	{
		desiredVelocity = Vector3.Normalize((Player.transform.position - Enemy.transform.position)) * topSpeed;
		Vector3 steering = Vector3.ClampMagnitude(desiredVelocity - velocity, maxForce);
		steering = steering / mass;
		velocity = Vector3.ClampMagnitude(velocity + steering, topSpeed);
		Enemy.transform.Translate(velocity * Time.deltaTime);
		Enemy.transform.Translate(velocity * Time.deltaTime, Space.World);

	}
}
