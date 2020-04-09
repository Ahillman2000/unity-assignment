using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAnimationScript : MonoBehaviour
{
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Collider PlayerCollider = Player.GetComponent<Collider>();

        if (other == PlayerCollider)
        {

        }
    }
}
