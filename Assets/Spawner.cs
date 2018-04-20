using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject zombie;
    public Transform target;
    public Canvas can;
    // Use this for initialization
    void Start () {
        zombie = GameObject.Find("Zombie");
        target = GameObject.Find("Walk+Shoot1").transform;
        //Canvas can = GetComponent<Canvas>();
        
        InvokeRepeating("SpawnZombie", 1, 1);
        
    }
	

    void SpawnZombie()
    {
        GameObject ZombieClone = Instantiate(zombie, new Vector3(Random.Range(target.transform.position.x - 20, target.transform.position.x + 20), (0.0f), Random.Range(target.transform.position.z - 20, target.transform.position.z + 20)), Quaternion.Euler(0, 0, 0)) as GameObject;
        ZombieClone.transform.parent = GameObject.Find("Zombs").transform;

    }

}
