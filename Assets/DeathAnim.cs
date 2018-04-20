using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class DeathAnim : MonoBehaviour {
    public GameObject DeadGirl;
    public AudioClip shoot;
    public AudioSource audioSource;
    public ParticleSystem blood;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Blood()
    {
        ParticleSystem stepsclone = Instantiate(blood, new Vector3(DeadGirl.transform.position.x, DeadGirl.transform.position.y, DeadGirl.transform.position.z), Quaternion.FromToRotation(new Vector3(90, 0, 0), new Vector3(0, 0, 1))) as ParticleSystem;

    }
    void Gun()
    {
        audioSource.PlayOneShot(shoot);

    }
}
