using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnerSCRIPT : MonoBehaviour {

	public GameObject zombie;
	GameObject player;
	// Use this for initialization
	void Start () {
		


	}

	public void spawnerObj(int increaseHealth)
	{
		
		player = GameObject.Find("Player");
		Debug.Log("spawObj at "+ this.gameObject.name);
		//for(int i = 0; i <= zombieCount; i++){
			//SpawnPos = new Vector3(transform.position);
			
			zombie = Instantiate(Resources.Load ("Insectoid"), this.gameObject.transform) as GameObject;
			zombie.GetComponent<ShootableBox>().increaseHealth(increaseHealth);

			//Debug.Log("zombie spawned at pos :" + zombie.transform.position);
		//}
		
	}

	


}
