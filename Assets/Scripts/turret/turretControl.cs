using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretControl : MonoBehaviour
{
    TurretCameraTrigger turretCameraTrigger;

    private GameObject Player;
    public GameObject Turret;
    public GameObject Barrel;

    GameObject lightning;
    GameObject charge;
    GameObject steam;

    public bool can_move = true;

    private float turret_speed = 50;
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
        
        lightning = GameObject.Find("Lightning");
        charge = GameObject.Find("Charge");
        steam = GameObject.Find("Steam");

        min_barrel_x_clamp = -0.06162845f;
        max_barrel_x_clamp = 0.06162845f;

        lightning.SetActive(false);
        charge.SetActive(false);
        steam.SetActive(false);
    }

    private void TurretMovement()
    {
        current_barrel_x = Mathf.Clamp(Barrel.transform.rotation.x, min_barrel_x_clamp, max_barrel_x_clamp);
        //print(current_barrel_x);

        if (Input.GetKey(KeyCode.A))
        {
            Turret.transform.Rotate(0, -turret_speed * Time.deltaTime, 0);
            //print("rotate turret left");
        }
        if (Input.GetKey(KeyCode.D))
        {
            Turret.transform.Rotate(0, turret_speed * Time.deltaTime, 0);
            //print("rotate turret right");
        }

        if (Input.GetKey(KeyCode.W))
        {
            /*if (current_barrel_x < max_barrel_x_clamp)
            {
                Barrel.transform.Rotate(-turret_speed * Time.deltaTime, 0, 0);
            }*/
            Barrel.transform.Rotate(-turret_speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            /*if (current_barrel_x > min_barrel_x_clamp)
            {
                Barrel.transform.Rotate(turret_speed * Time.deltaTime, 0, 0);
            }*/
            Barrel.transform.Rotate(turret_speed * Time.deltaTime, 0, 0);
        } 
    }

    void LightningControl ()
    {
        if (Input.GetKey(KeyCode.F))
        {
            steam.SetActive(false);
            lightning.SetActive(false);
            charge.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            charge.SetActive(false);
            lightning.SetActive(true);
            steam.SetActive(true);
        }
    }

    private void Update()
    {
        turret_y = Turret.transform.rotation.eulerAngles.y;
        //print(turret_y);

        if (turretCameraTrigger.in_turret)
        {
            TurretMovement();
            LightningControl();
        }
        else
        {
            Turret.transform.rotation = Quaternion.Euler(0, turret_y, 0);
            lightning.SetActive(false);
        }
    }
}
