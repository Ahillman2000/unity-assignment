using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogPickupTrigger : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void awake()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            player.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }
}
