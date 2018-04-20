using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {
    public Transform target;
    public float speed;
    public Canvas can;
    public GameObject Zombie;
    // Use this for initialization
    void Start () {
        speed = 2.0f;
        target = GameObject.Find("Walk+Shoot1").transform;
        Canvas can = GetComponent<Canvas>();
        Zombie = GameObject.Find("Zombie(Clone)");


    }

    // Update is called once per frame
    void Update () {
        if (can.GetComponent<Characters>().invis == false )
        {
            float step = speed * Time.deltaTime;
            Vector3 targetDir = target.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
            //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        
    }
   
}
