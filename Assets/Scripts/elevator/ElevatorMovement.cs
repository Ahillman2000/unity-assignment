using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    EthanParenting ethanParenting;

    private GameObject elevator;
    public GameObject startPos;
    public GameObject destinationPos;

    public float speed = 3.0f;
    private bool to = true;
    private float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        elevator = GameObject.Find("elevator");
        ethanParenting = GameObject.Find("elevator").GetComponent<EthanParenting>();

        elevator.transform.position = startPos.transform.position;
    }

    private void FixedUpdate()
    {
        if (ethanParenting.on_elevator == true)
        {
            elapsedTime += Time.deltaTime;

            float step = speed * Time.deltaTime;

            if (elapsedTime > 2.0f)
            {
                if (to == true)
                {
                    transform.position = Vector3.MoveTowards(transform.position, destinationPos.transform.position, step);
                }
                if (to == false)
                {
                    transform.position = Vector3.MoveTowards(transform.position, startPos.transform.position, step);
                }
            }

            if (to == true)
            {
                if (transform.position == destinationPos.transform.position)
                {
                    to = false;
                    elapsedTime = 0;
                }
            }

            if (to == false)
            {
                if (transform.position == startPos.transform.position)
                {
                    to = true;
                    elapsedTime = 0;
                }
            }
        }
    }   
}
