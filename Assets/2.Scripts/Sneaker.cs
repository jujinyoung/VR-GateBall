using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sneaker : MonoBehaviour
{
    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "STICK")
        {
            transform.GetChild(2).GetComponent<Rigidbody>().velocity = col.gameObject.GetComponent<Rigidbody>().velocity *5;
            transform.GetChild(2).GetComponent<Rigidbody>().angularVelocity = col.gameObject.GetComponent<Rigidbody>().angularVelocity *5;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
