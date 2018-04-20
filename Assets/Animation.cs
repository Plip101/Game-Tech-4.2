using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour {
    private Animator animator;
    public float Walk = 4;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("space"))
        {
            animator.SetBool("Jump", true);
        }
        else if (!Input.GetKey("space"))
        {
            animator.SetBool("Jump", false);
        }
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            
            animator.SetBool("Walk", true);

        }
        else if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            animator.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))

        {
            animator.SetBool("Run", true);
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Run", false);
        }
        if (Input.GetKey("r"))
        {
            animator.SetBool("Sit", true);
        }
        if (!Input.GetKey("r"))
        {
            animator.SetBool("Sit", false);
        }
        
        if (animator == null) return;
        
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        Move(x, y);
	}

    private void Move(float x, float y)
    {
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        

    }
}
