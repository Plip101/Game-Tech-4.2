using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float walkSpeed;
    public float runSpeed;
    float x,z;
    private Animator animator;
    public GameObject shield, beam;
    public bool createbeam;
    public GameObject Player;

    // Use this for initialization
    void Start () {
        walkSpeed = 2.5f;
        runSpeed = 7.5f;
        animator = GetComponent<Animator>();
        createbeam = false;
       Player = GameObject.Find("Walk+Shoot1");

        //  beam = GameObject.Find("Beam(Clone)");
    }

    // Update is called once per frame
    void Update () {
        
        if (animator.GetBool("Walk") )
        {
            x = Input.GetAxis("Horizontal") * Time.deltaTime * walkSpeed * 60;
            z = Input.GetAxis("Vertical") * Time.deltaTime * walkSpeed;
        }
        if (animator.GetBool("Run") )
        {
            x = Input.GetAxis("Horizontal") * Time.deltaTime * runSpeed * 25;
            z = Input.GetAxis("Vertical") * Time.deltaTime * runSpeed;

        }
        

    
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
       /* float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);*/
    }
}
