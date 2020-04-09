using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCameraTrigger : MonoBehaviour
{
    public Camera triggeredCam;
    public Camera liveCam;

    private GameObject Player;
    Collider PlayerCollider;

    public bool can_move = true;
    public bool in_turret = false;

    void Awake()
    {
        liveCam = Camera.allCameras[0];

        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = Player.GetComponent<Collider>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other == PlayerCollider && Input.GetKeyDown(KeyCode.G) && triggeredCam.enabled == false)
        {
            in_turret = true;
            can_move = false;
            triggeredCam.enabled = true;
            liveCam.enabled = false;

            //print("enter turret");
        }

        else if(Input.GetKeyDown(KeyCode.G) && triggeredCam.enabled == true)
        {
            in_turret = false;
            can_move = true;
            liveCam.enabled = true;
            triggeredCam.enabled = false;

            //print("exit turret");
        }
    }
}
