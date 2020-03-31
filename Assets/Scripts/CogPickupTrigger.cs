using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogPickupTrigger : MonoBehaviour
{
    //private GameObject player;
    //private GameObject gear;

    private bool picked_up = false;

    // Start is called before the first frame update
    void awake()
    {

    }

    void OnTriggerStay(Collider other)
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Collider playerCollider = player.GetComponent<Collider>();

        GameObject gear = GameObject.FindGameObjectWithTag("Gear");
        Collider gearCollider = gear.GetComponent<Collider>();

        //print("gear collision");
        print(picked_up);

        if (Input.GetKeyDown(KeyCode.P) && other == playerCollider && picked_up == false)
        {
            print("gear picked up");
            gear.transform.parent = player.transform;
            picked_up = true;
        }

        else if (Input.GetKeyDown(KeyCode.P) && picked_up == true)
        {
            picked_up = false;
            print("gear dropped");
            //gear.transform.parent = gear.transform;
            gear.transform.parent = null;
        }

    }

    /*private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            gear.transform.parent = null;
        }
    }*/
}
