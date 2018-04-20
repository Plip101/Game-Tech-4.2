using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Characters : MonoBehaviour {
    private Animator animator;
    public int character;
    public Button c1, c2, c3, c4;
    public GameObject Base, Braid, Brow, Lash, High, Teeth, Tounge;
    public GameObject shield, Player;
    public Camera cam;
    public bool invis, createshield, createice;
    public ParticleSystem ice;
    public float Maxpower, Currentpower;
    public Slider powerbar;
    public Animator anim;

    // Use this for initialization
    void Start () {
        character = 1;
        Animator anim = GetComponent<Animator>();
        Button btn1 = c1.GetComponent<Button>();
        Button btn2 = c2.GetComponent<Button>();
        Button btn3 = c3.GetComponent<Button>();
        Button btn4 = c4.GetComponent<Button>();
        Slider powerbar = GetComponent<Slider>();
        animator = GetComponent<Animator>();
        Camera cam = GetComponent<Camera>();
        Player = GameObject.Find("Walk+Shoot1");
        GameObject Base = GetComponent<GameObject>();
        GameObject Braid = GetComponent<GameObject>();
        GameObject Brow = GetComponent<GameObject>();
        GameObject Lash = GetComponent<GameObject>();
        GameObject High = GetComponent<GameObject>();
        GameObject Teeth = GetComponent<GameObject>();
        GameObject Tounge = GetComponent<GameObject>();
        invis = false;
        createshield = false;
        createice = false;
        btn1.onClick.AddListener(Character1);
        btn2.onClick.AddListener(Character2);
        btn3.onClick.AddListener(Character3);
        btn4.onClick.AddListener(Character4);
        Maxpower = 100.0f;
        Currentpower = Maxpower;
        powerbar.value = PowerBar();
    }
	
	// Update is called once per frame
	void Update () {

        //Jane Powers
        if(Currentpower== 0)
        {
            Destroy(GameObject.Find("Shield(Clone)"));
        }
        if (character == 1 && Input.GetMouseButton(0) && Currentpower > 0)
        {
            Currentpower -= 1.0f;
            powerbar.value = PowerBar();
            if (createshield == false)
            {
                GameObject BeamClone = Instantiate(shield, new Vector3(Player.transform.position.x, Player.transform.position.y + 0.5f, Player.transform.position.z), Quaternion.Euler(0, 0, 0)) as GameObject;
                BeamClone.transform.parent = GameObject.Find("Walk+Shoot1").transform;
                createshield = true;
            }
            if (GameObject.Find("Shield(Clone)").transform.localScale.z < 4)
            {
                GameObject.Find("Shield(Clone)").transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            }
        }
        else if (!Input.GetMouseButton(0))
        {
            Destroy(GameObject.Find("Shield(Clone)"));
            createshield = false;
        }

        //Chilly Powers
        if (Currentpower == 0)
        {
            Destroy(GameObject.Find("Frost(Clone)"));
        }
        if (character == 2 && Input.GetMouseButton(0))
        {
            Currentpower -= 0.5f;
            powerbar.value = PowerBar();
           // anim.SetFloat("Speed")
            if (createice == false)
            {
                Vector3 playerPos = Player.transform.position;
                Vector3 playerDirection = Player.transform.forward;
                Quaternion playerRotation = Player.transform.rotation;
                float spawnDistance = 2;
                Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

                ParticleSystem FrostClone = Instantiate(ice, new Vector3(spawnPos.x, spawnPos.y+1f, spawnPos.z), playerRotation) as ParticleSystem;
                FrostClone.transform.Rotate(playerRotation.x, playerRotation.y, playerRotation.z);
                //FrostClone.transform.Translate(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
                FrostClone.transform.parent = GameObject.Find("Walk+Shoot1").transform;
                createice = true;
            }
        }
        else if (!Input.GetMouseButton(0))
        {
            Destroy(GameObject.Find("Frost(Clone)"));
            createice = false;
        }

        //Speedy Powers
        if (character == 3 && Input.GetKey(KeyCode.LeftShift))
        {
            Currentpower -= 0.5f;
            powerbar.value = PowerBar();
            if (Currentpower > 0)
            {
                Player.GetComponent<Movement>().runSpeed = 20.0f;

                if (cam.fieldOfView < 80)
                {
                    cam.fieldOfView += 0.2f;
                }
            }
             if(Currentpower == 0)
            {
                Player.GetComponent<Movement>().runSpeed = 7.5f;
                if (cam.fieldOfView > 60)
                {
                    cam.fieldOfView -= 0.2f;
                }
            }
        }
        else
        {
            Player.GetComponent<Movement>().runSpeed = 7.5f;
            if (cam.fieldOfView > 60)
            {
                cam.fieldOfView -= 0.2f;
            }
        }

        //Shifty Powers
        if (character == 4 && Input.GetMouseButton(0) && Currentpower > 0)
        {
            Currentpower -= 0.35f;
            powerbar.value = PowerBar();
            Base.GetComponent<Renderer>().enabled = false;
            Braid.GetComponent<Renderer>().enabled = false;
            Brow.GetComponent<Renderer>().enabled = false;
            Lash.GetComponent<Renderer>().enabled = false;
            High.GetComponent<Renderer>().enabled = false;
            Teeth.GetComponent<Renderer>().enabled = false;
            Tounge.GetComponent<Renderer>().enabled = false;
            invis = true;
        }
        else
        {
            Base.GetComponent<Renderer>().enabled = true;
            Braid.GetComponent<Renderer>().enabled = true;
            Brow.GetComponent<Renderer>().enabled = true;
            Lash.GetComponent<Renderer>().enabled = true;
            High.GetComponent<Renderer>().enabled = true;
            Teeth.GetComponent<Renderer>().enabled = true;
            Tounge.GetComponent<Renderer>().enabled = true;
            invis = false;
        }
        if (!Input.GetMouseButton(0))
        {
            Currentpower += 0.25f;
            powerbar.value = PowerBar();
        }
        
        if (Currentpower < 0)
        {
            Currentpower = 0;
        }
        if (Currentpower > 100)
        {
            Currentpower = 100;
        }
        //button colors
        if(character == 1)
        {
            c1.GetComponent<Image>().color = Color.red;
        }
        else {
            c1.GetComponent<Image>().color = Color.white;
        }
        if (character == 2)
        {
            c2.GetComponent<Image>().color = Color.red;
        }
        else
        {
            c2.GetComponent<Image>().color = Color.white;
        }
        if (character == 3)
        {
            c3.GetComponent<Image>().color = Color.red;
        }
        else
        {
            c3.GetComponent<Image>().color = Color.white;
        }
        if (character == 4)
        {
            c4.GetComponent<Image>().color = Color.red;
        }
        else
        {
            c4.GetComponent<Image>().color = Color.white;
        }


    }

    void Character1() //Jane
    {
        character = 1;
    }
    void Character2() //Chilly
    {
        character = 2;
    }
    void Character3() //Speedy
    {
        character = 3;
    }
    void Character4() //Shifty
    {
        character = 4;
    }
    float PowerBar()
    {
        return Currentpower / Maxpower;
    }
}
