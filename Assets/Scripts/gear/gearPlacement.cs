using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gearPlacement : MonoBehaviour
{
    gearRight1Pickup gearPickup;

    GameObject player;
    Collider playerCollider;

    GameObject gondola;
    GameObject gear;
    GameObject scene;

    public bool gear_placed = false;
    private bool run_animation_1 = false;

    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<Collider>();

        scene = GameObject.Find("Maya files");
        gear = GameObject.Find("gearRight1");
        gondola = GameObject.Find("groupGondola");

        gearPickup = gear.GetComponent<gearRight1Pickup>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == playerCollider && gearPickup.picked_up == false && Input.GetKeyDown(KeyCode.P))
        {
            //print("within placement area, gear picked up and pressed p to place");
            gear_placed = true;
        }

    }

    private void Update()
    {
        if (gear_placed)
        {
            Vector3 gear_position = new Vector3(-5.184f, 17.804f, 4.872f);
            Quaternion gear_rotation = new Quaternion(0, 0, 0, 1);

            //print("gear placed");

            gear.transform.SetPositionAndRotation(gear_position, gear_rotation);
            gear_placed = false;
            run_animation_1 = true;
        }

        if (run_animation_1)
        {
            gear.transform.parent = gondola.transform;
        }
    }
}
