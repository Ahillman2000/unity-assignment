using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GondolaAnimation : MonoBehaviour
{
    Animator anim;
    GameObject player;
    Collider playerCollider;

    gearPlacement gearPlacement;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<Collider>();

        anim = GetComponent<Animator>();
        //anim.SetLayerWeight(1, 1f);

        gearPlacement = GameObject.Find("CogPlacementCollision").GetComponent<gearPlacement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider && gearPlacement.run_animation_1)
        {
            //print("run animation 1");
            anim.SetBool("Animation1", true);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //print("run animation 2");
            anim.SetBool("Animation2", true);
        }
    }
}