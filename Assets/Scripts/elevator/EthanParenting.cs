using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanParenting : MonoBehaviour
{
    private GameObject player;
    public bool on_elevator = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            on_elevator = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            on_elevator = false;
        }
    }
}
