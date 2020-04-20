using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupShipScript : MonoBehaviour
{
    GondolaAnimation gondolaAnimation;
    GameObject ship;
    GameObject[] shipPart;

    public GameObject shipStart;
    public GameObject shipEnd;

    bool shipLanding = false;

    private void Awake()
    {
        gondolaAnimation = GameObject.Find("Maya files").GetComponent<GondolaAnimation>();
        ship = GameObject.Find("group_ship");
        ship.gameObject.SetActive(false);

        shipPart = GameObject.FindGameObjectsWithTag("Ship");
    }
    void Update()
    {
        //print(gondolaAnimation.run_animation_2);
        //print(ship.transform.position);

        if (gondolaAnimation.run_animation_2)
        {
            //print("ship activated");
            ship.gameObject.SetActive(true);
            shipLanding = true;
        }

        // Debug controls for ship
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            //print("ship activated");
            ship.gameObject.SetActive(true);
            shipLanding = true;
        }*/

        if (shipLanding)
        {
            ship.transform.position = Vector3.MoveTowards(ship.transform.position, shipEnd.transform.position, 3.0f * Time.deltaTime);
        }

        if (ship.transform.position == shipEnd.transform.position)
        {
            //print("ship landed");
        }
    }
}
