using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerupScript : MonoBehaviour {

	public GameObject powerup;

	public void spawnerObj(int previousPowerup)
	{
		string powerupType = "";
		int rdmPowerup = UnityEngine.Random.Range(1, 5);

		if(rdmPowerup == previousPowerup){
			print("SAME AS LAST TIME");
			spawnerObj(rdmPowerup);
			return;
		}
		if(rdmPowerup == 1)
			powerupType = "Heart";

		else if(rdmPowerup == 2)
			powerupType = "Diamondo";

		else if(rdmPowerup == 3)
			powerupType = "SphereGemLarge";

		else if(rdmPowerup == 4)
			powerupType = "Hexgon";

		powerup = Instantiate(Resources.Load(powerupType)) as GameObject;
		powerup.transform.position = transform.position;
	}
}