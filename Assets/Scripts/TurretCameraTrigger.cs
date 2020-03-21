using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCameraTrigger : MonoBehaviour
{
    public Camera triggeredCam;
    public Camera liveCam;
    private bool inTurret = false;

    void Awake()
    {
        liveCam = Camera.allCameras[0];
    }

    void OnTriggerStay(Collider other)
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Collider PlayerCollider = Player.GetComponent<Collider>();

        //if (other == PlayerCollider && Input.GetKeyDown(KeyCode.G) && inTurret == false)
        if (other == PlayerCollider && Input.GetKeyDown(KeyCode.G) && triggeredCam.enabled == false)
        {
            //inTurret = true;

            triggeredCam.enabled = true;
            liveCam.enabled = false;

            print("in box collider g pressed 1");
        }

        //if (/*other == PlayerCollider &&*/ Input.GetKeyDown(KeyCode.G) && inTurret == true)
        else if(Input.GetKeyDown(KeyCode.G) && triggeredCam.enabled == true)
        {
            liveCam.enabled = true;
            triggeredCam.enabled = false;

            print("in box collider g pressed 2");

            //inTurret = false;
        }
    }
}
