using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GondolaAnimation : MonoBehaviour
{
    Animator anim;

    GameObject gondola;
    GameObject player;
    Collider playerCollider;

    gearPlacement gearPlacement;

    public bool run_animation_2 = false;
    bool scene_idle_2 = false;

    private void Awake()
    {
        gondola = GameObject.Find("groupGondola");
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
        //print(gondola.transform.position.x);

        if (gondola.transform.position.x >= 14.3 && gondola.transform.position.x <= 14.5)
        {
            //print("gondola idle at 14.433");
            scene_idle_2 = true;
        }

        if (Input.GetKey(KeyCode.Space) && scene_idle_2)
        {
            run_animation_2 = true; 
            //print("run animation 2");
            anim.SetBool("Animation2", true);
        }
    }
}