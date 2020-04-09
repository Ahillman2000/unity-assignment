using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCamera : MonoBehaviour
{

    public Camera FollowCam;
    public Camera StaticCam;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        Player.GetComponent<AudioListener>().enabled = true;
        StaticCam.GetComponent<AudioListener>().enabled = false;

        FollowCam.enabled = true;
        StaticCam.enabled = false;
    }
}
