using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAnimationScript : MonoBehaviour
{
    GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Collider PlayerCollider = Player.GetComponent<Collider>();

        if (other == PlayerCollider)
        {

        }
    }
}
