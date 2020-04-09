﻿  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    TurretCameraTrigger can_move;

    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.0f;

    private Animator anim;
    private HashIDs hash;

    private float elapsedTime = 0;
    private bool noBackMov = true;

    private void Awake()
    {
        can_move = GameObject.Find("TurretCameraTrigger").GetComponent<TurretCameraTrigger>();
        
        anim = GetComponent <Animator> ();
        anim.SetLayerWeight(1, 1f);
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
    }

    private void Update()
    {

        float v = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X");

        MovementManager(v);

        elapsedTime += Time.deltaTime;
    }

    void MovementManager (float vertical)
    {
        if (can_move.can_move)
        {
            //print(can_move.can_move);

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
                noBackMov = true;
            }

            else if (vertical < 0.2)
            {
                anim.SetFloat(hash.speedFloat, 0);
                noBackMov = true;
            }

            Rigidbody ourBody = this.GetComponent<Rigidbody>();

            if (Input.GetKey(KeyCode.S))
            {
                if (noBackMov == true)
                {
                    elapsedTime = 0;
                    noBackMov = false;
                }

                Vector3 moveBack = new Vector3(0.0f, 0.0f, -0.03f);
                moveBack = ourBody.transform.TransformDirection(moveBack);
                ourBody.transform.position += moveBack;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                print("jump");
            }
        }
        else
        {
            //print(can_move.can_move);
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