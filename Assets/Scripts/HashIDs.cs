﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int walkState;
    public int runState;

    public int LeftTurn;
    public int RightTurn;

    public int speedFloat;


    private void Awake()
    {
        walkState = Animator.StringToHash("Walk");
        runState = Animator.StringToHash("Run");

        LeftTurn = Animator.StringToHash("LeftTurn");
        RightTurn = Animator.StringToHash("RightTurn");

        speedFloat = Animator.StringToHash("Speed");
    }
}
