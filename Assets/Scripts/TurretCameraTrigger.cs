using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCameraTrigger : MonoBehaviour
{
    public Camera triggeredCam;
    public Camera liveCam;

    private GameObject Player;
    public GameObject Turret;
    public GameObject Barrel;

    public bool can_move = true;
    private bool in_turret = false;

    private float turret_speed = 100;
    private float turret_y;

    void Awake()
    {
        liveCam = Camera.allCameras[0];
    }

    void OnTriggerStay(Collider other)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Turret = GameObject.Find("group_turret");
        Barrel= GameObject.Find("group_turret_barrel");
        Collider PlayerCollider = Player.GetComponent<Collider>();

        if (other == PlayerCollider && Input.GetKeyDown(KeyCode.G) && triggeredCam.enabled == false)
        {
            print("enter turret");

            triggeredCam.enabled = true;
            liveCam.enabled = false;
            can_move = false;
            in_turret = true;

            Player.transform.parent = Turret.transform;
        }

        else if(Input.GetKeyDown(KeyCode.G) && triggeredCam.enabled == true)
        {
            liveCam.enabled = true;
            triggeredCam.enabled = false;
            can_move = true;
            in_turret = false;

            Turret.transform.rotation = Quaternion.Euler(0, turret_y, 0);

            Player.transform.parent = null;

            print("exit turret");

            //Turret.transform.Rotate(0, -90, 0);

        }
    }

    private void Update()
    {

        if (in_turret)
        {

            Player.transform.parent = Turret.transform;

            turret_y = Turret.transform.rotation.eulerAngles.y;
            //print(turret_y);
            //print(Barrel.transform.rotation.eulerAngles.x);

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

            // Barrel.transform.rotation.eulerAngles.x
            // Mathf.Clamp(Barrel.transform.rotation.eulerAngles.x, -20, 10)
            float barrel_x = Barrel.transform.rotation.eulerAngles.x;
            float upper_barrel_x = 340;
            float lower_barrel_x = 10;

            if (barrel_x > upper_barrel_x || barrel_x < lower_barrel_x)
            {
                //print("within clamp");
            }

            if (Input.GetKey(KeyCode.W))
            {
                Barrel.transform.Rotate(-turret_speed * Time.deltaTime, 0, 0);
                //print("rotate barrel up");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Barrel.transform.Rotate(turret_speed * Time.deltaTime, 0, 0);
                //print("rotate barrel down");
            }
        }
    }
}
