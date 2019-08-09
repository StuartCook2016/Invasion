using UnityEngine;
using System.Collections;
 
public class Bullets : MonoBehaviour
{

    public GameObject BulletEmitter;
    public GameObject Grenade;
    public float BulletForce;
    public int maxGrenades = 3;
	public int currentGrenades;

    void Start()
    {
        currentGrenades = maxGrenades;
    }
	// Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown(1) && currentGrenades > 0)
        {
            currentGrenades--;
            //Instantiate the bullet and rotate.
            GameObject TemporaryBullet;
            TemporaryBullet = Instantiate(Grenade,BulletEmitter.transform.position,BulletEmitter.transform.rotation) as GameObject;
            //Get the Rigidbody component from the instantiated Bullet and give the bullet forward momentum.
            Rigidbody TempBody;
            TempBody = TemporaryBullet.GetComponent<Rigidbody>();
            TempBody.AddForce(transform.forward * BulletForce);

        }
    }
}

