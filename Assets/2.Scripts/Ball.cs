using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallState{gate1,gate2,gate3}
public class Ball : MonoBehaviour
{
    public BallState ballState = BallState.gate1;
    [HideInInspector]
    public bool ballspark = true;
    private void OnTriggerEnter(Collider col)
    {   
        if(col.tag == "WALL")
        {
            Debug.Log("벽충돌");
            var pos = col.ClosestPoint(transform.position);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            switch(col.name)
            {
                case "Right":
                    gameObject.transform.position = pos + new Vector3(-1,0,0);
                    break;
                case "Left":
                    gameObject.transform.position = pos + new Vector3(1,0,0);
                    break;
                case "Up":
                    gameObject.transform.position = pos + new Vector3(0,0,-1);
                    break;
                case "Down":
                    gameObject.transform.position = pos + new Vector3(0,0,1);
                    break;    
            }  
        }
    }

    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "STICK" || col.gameObject.tag == "BALL")
        {
            gameObject.GetComponent<Rigidbody>().velocity = col.gameObject.GetComponent<Rigidbody>().velocity;
            gameObject.GetComponent<Rigidbody>().angularVelocity = col.gameObject.GetComponent<Rigidbody>().angularVelocity;
        }
        if(col.gameObject.tag == "BALL" && col.gameObject.GetComponent<Ball>().ballspark)
        {
            StartCoroutine(CollideBall(col));
            col.gameObject.GetComponent<Ball>().ballspark = false;
        }
    }

    IEnumerator CollideBall(Collision col){
        yield return new WaitForSeconds(2.0f);
        TutorialManager.instance.Fadestart();
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        col.gameObject.transform.position = gameObject.transform.position + new Vector3(0.1f,0,0);
    }
}
