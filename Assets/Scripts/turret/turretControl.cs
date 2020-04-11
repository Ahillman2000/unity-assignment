using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretControl : MonoBehaviour
{
    TurretCameraTrigger turretCameraTrigger;

    private GameObject Player;
    public GameObject Turret;
    public GameObject Barrel;

    public bool can_move = true;

    private float turret_speed = 100;
    private float turret_y = -90;

    private float current_barrel_x;
    private float min_barrel_x_clamp;
    private float max_barrel_x_clamp;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Turret = GameObject.Find("group_turret");
        Barrel = GameObject.Find("group_turret_barrel");
        turretCameraTrigger = GameObject.Find("TurretCameraTrigger").GetComponent<TurretCameraTrigger>();

        min_barrel_x_clamp = -0.06162845f;
        max_barrel_x_clamp = 0.06162845f;
    }

    private void Update()
    {
        if (turretCameraTrigger.in_turret)
        {
            turret_y = Turret.transform.rotation.eulerAngles.y;
            //print(turret_y);
            current_barrel_x = Mathf.Clamp(Barrel.transform.rotation.x, min_barrel_x_clamp, max_barrel_x_clamp);
            print(current_barrel_x);

            if (Input.GetKey(KeyCode.A))
            {
                Turret.transform.Rotate(0, -turret_speed * Time.deltaTime, 0);
                //print("rotate turret left");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Turret.transform.Rotate(0, turret_speed * Time.deltaTime, 0);
                //print("rotate turret right");
            }
           
            if (Input.GetKey(KeyCode.W))
            {
                if (current_barrel_x < max_barrel_x_clamp)
                {
                    Barrel.transform.Rotate(-turret_speed * Time.deltaTime, 0, 0);
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (current_barrel_x > min_barrel_x_clamp)
                {
                    Barrel.transform.Rotate(turret_speed * Time.deltaTime, 0, 0);
                }
            }
        }
        else
        {
            Turret.transform.rotation = Quaternion.Euler(0, turret_y, 0);
        }
    }
}
