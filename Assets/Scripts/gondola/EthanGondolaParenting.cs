using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanGondolaParenting : MonoBehaviour
{
    private GameObject player;
    private Collider playerCollider;
    private GameObject gondola;

    public bool in_gondola = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<Collider>();
        gondola = GameObject.Find("groupGondola");
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            in_gondola = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            in_gondola = false;
        }
    }
    
    /*private void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider)
        {
            in_gondola = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        in_gondola = false;
    }

    private void Update()
    {
        if (in_gondola)
        {
            player.transform.parent = gondola.transform;
        }
        else
        {
            //player.transform.parent = null;
        }
    }*/
}
