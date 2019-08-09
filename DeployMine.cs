using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployMine : MonoBehaviour {

    public GameObject BulletEmitter;
    public GameObject Mines;
    public float BulletForce;
    public int mineCount = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("f"))
        {
            if(mineCount <=0){
                return;
            }
            mineCount--;
			//Instantiate the Mine and rotate.
            GameObject TemporaryBullet;
            TemporaryBullet = Instantiate(Mines,BulletEmitter.transform.position,BulletEmitter.transform.rotation) as GameObject;
            //Get the Rigidbody component from the instantiated Mine and give the bullet Mine momentum.
            Rigidbody TempBody;
            TempBody = TemporaryBullet.GetComponent<Rigidbody>();
            TempBody.AddForce(transform.forward * BulletForce);
		}
		
	}
}