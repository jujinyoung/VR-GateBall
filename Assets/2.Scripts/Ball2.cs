using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{
    [HideInInspector]
    public Vector3 pos;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "STICK")
        { 
            StartCoroutine(Respark());
        }
    }
    IEnumerator Respark()
    {
        yield return new WaitForSeconds(5.0f);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.transform.position = pos;
    }
}
