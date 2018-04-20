using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaChannel : MonoBehaviour {

    public AudioClip step, jump, shoot;
    public AudioSource audioSource;
    public ParticleSystem steps;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    

    void Step()
    {
        audioSource.PlayOneShot(step);
        ParticleSystem stepsclone = Instantiate(steps) as ParticleSystem;
        stepsclone.transform.parent = GameObject.Find("Walk+Shoot1").transform;

    }
    void Jump()
    {
        audioSource.PlayOneShot(jump);

    }



}
