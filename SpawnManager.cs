using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SpawnManager : MonoBehaviour {

	//public int NoOfZombies;
	int currentlySpawned = 0;
	List<int> randList;
	int spawnRand;
	int currentChild;
	public int waveZombies = 5;
	public bool gameRunning;
	int enemyHealth = 2;
	public int currentBugs = 5;

	// Use this for initialization
	void Start () 
	{
		chooseSpawners(waveZombies, enemyHealth);
		gameRunning = true;		
		
	}

	void Update(){
		if(gameRunning)
		{
         if (GameObject.Find ("Insectoid(Clone)") == null) 
		 {
             Debug.Log ("wave done");
			 
			 waveZombies = waveZombies + 5;
			 if (waveZombies <= 25)
			 {
				 enemyHealth = enemyHealth + 2;
				 chooseSpawners(waveZombies, enemyHealth);
				 currentBugs = waveZombies;
				 Debug.Log("New Wave");
			 }
			 else
			 {
				 Debug.Log("Game Complete");
				 gameRunning = false;
				 SceneManager.LoadScene("Game Complete", LoadSceneMode.Additive);
			 }
			 
         }
		}
	}
	
	void chooseSpawners(int NoOfZombies, int increaseHealth)
	{
		Debug.Log("Spawning Mobs");
		Transform[] allChildren = GetComponentsInChildren<Transform>();
		currentlySpawned = 0;
		randList = new List<int>();
		// chosenArr[0] = Random.Range(0, allChildren.Length);
		Debug.Log(randList);

		while(currentlySpawned < NoOfZombies)
		{
			
			spawnRand = Random.Range(1, allChildren.Length);
			if(randList.Contains(spawnRand))
			{
				//Debug.Log("already found");
				continue;
			}
			else
			{
			
				randList.Add(spawnRand);
				SpawnerSCRIPT callScript = (SpawnerSCRIPT) allChildren[spawnRand].GetComponent(typeof(SpawnerSCRIPT));
				callScript.spawnerObj(increaseHealth);
				currentlySpawned++;

			}
		}
	}

	public int GetBugNo()
	{
		int bugs = currentBugs;

		return bugs;
	}


}
