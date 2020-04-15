using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningScript : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Ship"))
        {
            //print("hit ship");
            Destroy(other);
        }
    }
}
