using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector]
    public bool ballspark = true;

    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "BALL")
        {
            StopMove(gameObject);
            
            if(ballspark)
            {
                StartCoroutine(CollideBall(col.gameObject));
                ballspark = false;
            }
        }
        
    }

    IEnumerator CollideBall(GameObject col){
        Debug.Log(col.name);
        yield return new WaitForSeconds(2.0f);
        TutorialManager.instance.Fadestart();
        StopMove(col);
        col.transform.position = gameObject.transform.position + new Vector3(0,0,0.2f);
        Vector3 sneakerPos = gameObject.transform.position + new Vector3(0,0.1f,0.05f);
        TutorialManager.instance.SparkAttack(gameObject,col,sneakerPos);
    }

    void StopMove(GameObject obj){
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
