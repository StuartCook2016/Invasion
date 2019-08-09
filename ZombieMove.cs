using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour {

	[SerializeField]
	Transform _destination;

	GameObject player;

	NavMeshAgent _navMeshAgent;
	float distance;



	
	
	// Use this for initialization
	void Start () {

		_navMeshAgent = this.GetComponent<NavMeshAgent>();

	}
	
	void Update (){

		_navMeshAgent.SetDestination(GameObject.Find("Player").transform.position);
			
	}

}
