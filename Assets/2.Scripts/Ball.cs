using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector]
    public bool ballspark = true;
    bool stickcolcheck = false;
    AudioSource audioSource;
    private void Start() {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update() {
        if(stickcolcheck){
            if(gameObject.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                if(TutorialManager.instance.state == State.gate1)
                {
                    gameObject.transform.position = new Vector3(11.53f,0.03639915f,-10f);
                }
                TutorialManager.instance.Fadestart();
                stickcolcheck = false;
            }
            if(gameObject.GetComponent<Rigidbody>().velocity.magnitude<0.05f)
            {
                StopMove(gameObject);
            }
        }
    }
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
        if(col.gameObject.tag == "STICK")
        {
            audioSource.Play();
            stickcolcheck = true;
        }
        
    }

    IEnumerator CollideBall(GameObject col){
        Debug.Log(col.name);
        yield return new WaitForSeconds(2.0f);
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
