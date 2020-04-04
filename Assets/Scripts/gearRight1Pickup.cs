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
    Collider gearCollider;

    // Start is called before the first frame update
    void awake()
    {
        anim = GetComponent<Animator>();

        gear = GameObject.FindGameObjectWithTag("Gear");
        gearCollider = gear.GetComponent<Collider>();
    }

    void OnTriggerStay(Collider other)
    {
        // PLAYER
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Collider playerCollider = player.GetComponent<Collider>();

        // PICKUP LOCATION
        GameObject gearPickup = GameObject.Find("CogPickUpCollision");
        Collider gearPickUpCollider = gearPickup.GetComponent<Collider>();

        // PLACEMENT LOCATION
        GameObject gearPlacement = GameObject.Find("CogPlacementCollision");
        Collider gearPlacementCollider = gearPlacement.GetComponent<Collider>();

        if (Input.GetKeyDown(KeyCode.P) && other == playerCollider && picked_up == false)
        {
            print("gear picked up");
            gear.transform.parent = player.transform;
            picked_up = true;
        }

        /*else if (Input.GetKeyDown(KeyCode.P) && picked_up == true)
        {
            picked_up = false;
            print("gear dropped");
            //gear.transform.parent = gear.transform;
            gear.transform.parent = null;

            //anim.SetBool("CogPlaced", true);
        }*/

    }

    /*private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            gear.transform.parent = null;
        }
    }*/

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && picked_up == true)
        {
            picked_up = false;
            print("gear dropped");
            //gear.transform.parent = gear.transform;
            gear.transform.parent = null;

            //anim.SetBool("CogPlaced", true);
        }
    }
}
