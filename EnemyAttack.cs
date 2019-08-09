using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour {

	public float attackTime = 0.8f;
	public int attackDamage = 10;
	GameObject player;
	PlayerHealth playerHealth;
	Animator animated;
	private AudioSource attackAudio;

	bool inRange;
	float timer;

	// Use this for initialization
	void Start () 
	{
		animated = GetComponent<Animator>();
		attackAudio = GetComponent<AudioSource> ();
		player = GameObject.Find("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == player)
		{
			Debug.Log("in range");
			inRange = true;
			animated.SetBool("attacking", true);
			
			
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == player)
		{
			inRange = false;
			animated.SetBool("attacking", false);
			
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if(timer >= attackTime && inRange)
		{
			
			Attack();
		}
		if(playerHealth.currentHealth <= 0)
		{
			animated.SetBool("attacking", false);
			PlayerDead();
		}
	}
	void Attack()
	{
		timer = 0f;
		attackAudio.Play();
		if(playerHealth.currentHealth > 0)
		{
			
			playerHealth.TakeDamage(attackDamage);
		}
	}
	void PlayerDead()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
