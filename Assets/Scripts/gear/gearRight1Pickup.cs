using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gearRight1Pickup : MonoBehaviour
{
    public bool picked_up = false;

    // GEAR OBJECT
    GameObject player;
    Collider playerCollider;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<Collider>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other == playerCollider && Input.GetKeyDown(KeyCode.P) && picked_up == false)
        {
            //print("pick up");
            picked_up = true;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P) && picked_up == true )
        {
            //print("drop");
            picked_up = false;
        }
    }

    void Update()
    {
        //print("picked_up: " + picked_up);
      
        if (picked_up)
        {
            this.transform.parent = player.transform;
        }
        else
        {
            this.transform.parent = this.transform;
        }
    }
}
