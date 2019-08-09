using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployPowerup : MonoBehaviour {

	public int powerupCount;
	bool spawned = false;
	List<int> randList = new List<int>();
	int spawnRand;

	// Use this for initialization
	public void Start () 
	{
		ChooseSpawners(0);
	}
	
	public void ChooseSpawners(int previousPowerup)
	{
		Transform[] allChildren = GetComponentsInChildren<Transform>();

		spawnRand = Random.Range(2, allChildren.Length);
		randList.Add(spawnRand);
		print(allChildren[spawnRand]);
		PowerupScript callScript = (PowerupScript) allChildren[spawnRand].GetComponent(typeof(PowerupScript));
		
		callScript.spawnerObj(previousPowerup);
	}
}