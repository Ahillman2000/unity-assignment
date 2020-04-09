using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gearRight1Pickup : MonoBehaviour
{
    //private GameObject player;
    //private GameObject gear;

    private Animator anim;
    private bool picked_up = false;

    public bool CogPlaced = false;
    public bool Blockage = true;

    // GEAR OBJECT
    GameObject gear;
    GameObject player;
    Collider gearCollider;
    Collider playerCollider;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();

        gear = GameObject.FindGameObjectWithTag("Gear");
        gearCollider = gear.GetComponent<Collider>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<Collider>();
    }

    void OnTriggerStay(Collider other)
    {
        // PLAYER


        /*
        // PICKUP LOCATION
        GameObject gearPickup = GameObject.Find("CogPickUpCollision");
        Collider gearPickUpCollider = gearPickup.GetComponent<Collider>();

        // PLACEMENT LOCATION
        GameObject gearPlacement = GameObject.Find("CogPlacementCollision");
        Collider gearPlacementCollider = gearPlacement.GetComponent<Collider>();
        */

        
    }

    void Update()
    {
        print("picked_up: " + picked_up);

        if (Input.GetKeyDown(KeyCode.P) /*&& other == playerCollider*/ && picked_up == false)
        {
            picked_up = true;
        }

        else if (Input.GetKeyDown(KeyCode.P) && picked_up == true)
        {
            picked_up = false;
            //anim.SetBool("CogPlaced", true);
        }

        if (picked_up)
        {
            gear.transform.parent = player.transform;
        }
        else
        {
            //gear.transform.parent = gear.transform;
            gear.transform.parent = null;
        }
    }
}
