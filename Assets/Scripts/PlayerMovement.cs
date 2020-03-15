﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.0f;

    private Animator anim;
    private HashIDs hash;

    private void Awake()
    {
        anim = GetComponent <Animator> ();
        anim.SetLayerWeight(1, 1f);
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
    }

    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");

        //bool w = Input.GetKeyDown(KeyCode.W);
        //bool shift = Input.GetKeyDown(KeyCode.LeftShift);
        //bool space = Input.GetKeyDown(KeyCode.Space);

        //bool a = Input.GetKeyDown(KeyCode.A);
        //bool d = Input.GetKeyDown(KeyCode.D);

        float mouseX = Input.GetAxis("Mouse X");

        //Rotating(mouseX);
        MovementManager(v);
    }

    void MovementManager (float vertical)
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //anim.SetBool(hash.LeftTurn, true);
            anim.SetBool("LeftTurn", true);
            //print("going left");

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("LeftTurn", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //anim.SetFloat(hash.RightTurn, 1);
            anim.SetBool("RightTurn", true);
            //print("going right");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("RightTurn", false);
        }


        if (Input.GetKey(KeyCode.W))
        {
            anim.SetFloat(hash.speedFloat, 1.5f, speedDampTime, Time.deltaTime);
        }



        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat(hash.speedFloat, 21f, speedDampTime, Time.deltaTime);
        }

        else if (vertical < 0.2)
        {
            anim.SetFloat(hash.speedFloat, 0);
        }
        
    }

   /* void Rotating(float mouseXInput)
    {
        Rigidbody ourBody = this.GetComponent<Rigidbody>();

        if (mouseXInput != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, mouseXInput * sensitivityX, 0f);
            ourBody.MoveRotation(ourBody.rotation * deltaRotation);
        }
    }*/
}
