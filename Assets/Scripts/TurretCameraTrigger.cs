using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCameraTrigger : MonoBehaviour
{
    public Camera triggeredCam;
    public Camera liveCam;
    public bool inTurret = false;

    void awake()
    {
        liveCam = Camera.allCameras[0];
    }

    void OnTriggerStay(Collider other)
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Collider PlayerCollider = Player.GetComponent<Collider>();

        if (other == PlayerCollider && Input.GetKeyDown(KeyCode.G) && inTurret == false)
        {
            inTurret = true;
            triggeredCam.enabled = true;
            liveCam.enabled = false;

            liveCam = Camera.allCameras[0];

            triggeredCam.GetComponent<AudioListener>().enabled = true;
            Player.GetComponent<AudioListener>().enabled = false;
        }

        else if (other == PlayerCollider && Input.GetKeyDown(KeyCode.G) && inTurret == true)
        {
            inTurret = false;
            triggeredCam.enabled = false;
            liveCam.enabled = true;

            triggeredCam = Camera.allCameras[0];

            liveCam.GetComponent<AudioListener>().enabled = true;
            Player.GetComponent<AudioListener>().enabled = false;
        }
    }
}
