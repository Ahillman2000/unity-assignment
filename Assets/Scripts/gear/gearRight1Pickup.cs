using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gearRight1Pickup : MonoBehaviour
{
    public bool picked_up = false;

    GameObject gear;
    GameObject player;
    Collider playerCollider;

    gearPlacement gearPlacement;

    float gear_y;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<Collider>();
        gear = GameObject.Find("gearRight1");

        gearPlacement = GameObject.Find("CogPlacementCollision").GetComponent<gearPlacement>();
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
        gear_y = gear.transform.rotation.eulerAngles.y;
        //print(gear.transform.parent);

        if (picked_up)
        {
            gear.transform.parent = player.transform;
        }
        else if (picked_up == false && gearPlacement.run_animation_1 == false)
        {
            gear.transform.parent = null;
        }
    }
}
