using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootableBox : MonoBehaviour {

	
	public int currentHealth = 1000;
	
	public void Damage(int damageAmount){
		
		currentHealth -= damageAmount;
		Debug.Log("Boss Health: " + currentHealth);
		if(currentHealth <= 0){
			Destroy(gameObject);
		}
	}
}