using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;

    void OnTriggerEnter(Collider other)
    {
        //Teleport to EndRoom
        if(other.gameObject.tag == "Teleport")
        {
            transform.position = teleportTarget.position;
        }
    }

    void OnTriggerStay(Collider other)
    {
        //Teleport to EndRoom
        if (other.gameObject.tag == "Teleport")
        {
            transform.position = teleportTarget.position;
        }
    }

}
