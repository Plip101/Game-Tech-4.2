using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Points : MonoBehaviour {
    public Text points;
    public int score = 0;
    public GameObject cube;
    public bool start;
    public bool spawnfirst;
    public bool spawnSecond;
    public bool start2;
    public GameObject Player;

    void Start()
    {
        cube = GameObject.Find("CubePoints");
        Player = GameObject.Find("Walk+Shoot1");
        start = true;
        spawnfirst = false;
        spawnSecond = false;
        start2 = false;
}
    void Update()
    {
        if(spawnfirst == true)
        {
            cube.transform.Translate(Vector3.back * 150);
            start2 = true;
            start = false;
            spawnfirst = false;

        }
        if (spawnSecond == true)
        {
            cube.transform.Translate(Vector3.forward * 150);
            start = true;
            start2 = false;
            spawnSecond = false;

        }
    }
    void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.name == "Walk+Shoot1" && start == true)
        {
            Debug.Log(spawnfirst);
            //Destroy(this.gameObject);
            score += 1;
            points.text = "Score: " + score ;
            spawnfirst = true;


        }

        if (other.gameObject.name == "Walk+Shoot1" && start2 == true)
        {
            Debug.Log(spawnfirst);
            //Destroy(this.gameObject);
            score += 1;
            points.text = "Score: " + score;
            spawnSecond = true;
            

        }
    }
}
