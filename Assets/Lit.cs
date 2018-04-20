using UnityEngine;
using System.Collections;

public class Lit : MonoBehaviour
{
    public Canvas can;
    public GameObject Player, Dead, Zombie;
    private Camera newcam;
    public Camera org;
    public bool dead;
    public ParticleSystem frost;
    public Animator anim;
    public bool frozen = false;
    public float speed, slow;
    void Start()
    {
        dead = false;
        Player = GameObject.Find("Walk+Shoot1");
        Animator anim = GetComponent<Animator>();
        Zombie = GameObject.Find("Zombie(Clone)");
        GameObject Dead = GetComponent<GameObject>();
        Camera org = GetComponent<Camera>();
        Debug.Log("Found main camera: " + org);
        speed = 0.0f;
        slow = 0.05f;
    }
    void Update()
    {
        if(dead == true)
        {
            newcam.transform.Translate(Vector3.back *Time.deltaTime* 2);
        }
        if(frozen == true && speed < 2)
        {
            speed += 0.001f;
            anim.SetFloat("Speed", speed);
        }
        if(speed > 1)
        {
            frozen = false;
        }
    }
    void OnTriggerEnter(Collider other)
    
        {
        if (other.gameObject.name == "Shield(Clone)")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.name == "Frost(Clone)" && frozen == false)
        {
            anim.SetFloat("Speed", 0.0f);
            frozen = true;
        }
        if (other.gameObject.name == "Beam(Clone)")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.name == "Walk+Shoot1" && can.GetComponent<Characters>().character == 3 && Input.GetKey(KeyCode.LeftShift))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.name == "Walk+Shoot1" && can.GetComponent<Characters>().character == 3 && !Input.GetKey(KeyCode.LeftShift))
        {

            newcam = Instantiate(org,new Vector3(org.transform.position.x, org.transform.position.y, org.transform.position.z),Quaternion.FromToRotation(new Vector3(0, 90, 0), new Vector3(0, 0, 1)));
            Dead = Instantiate(Dead, new Vector3(org.transform.position.x, org.transform.position.y - 2.5f, org.transform.position.z), Quaternion.FromToRotation(new Vector3(0, 0, 0), new Vector3(0, 0, 1)));
            dead = true;
            Destroy(can);
            Destroy(Player);


        }
        else if (other.gameObject.name == "Walk+Shoot1" && can.GetComponent<Characters>().character == 1 || can.GetComponent<Characters>().character == 2 || can.GetComponent<Characters>().character == 4)
        {

            newcam = Instantiate(org, new Vector3(org.transform.position.x, org.transform.position.y, org.transform.position.z), Quaternion.FromToRotation(new Vector3(0, 90, 0), new Vector3(0, 0, 1)));
            Dead = Instantiate(Dead, new Vector3(org.transform.position.x, org.transform.position.y - 2.5f, org.transform.position.z), Quaternion.FromToRotation(new Vector3(0, 0, 0), new Vector3(0, 0, 1)));
            dead = true;
            Destroy(can);
            Destroy(Player);


        }

    }
}