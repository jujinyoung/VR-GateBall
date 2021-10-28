using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {   
        if(col.tag == "BALL")
        {
            var pos = col.ClosestPoint(transform.position);
            col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            switch(gameObject.name)
            {
                case "Right":
                    col.gameObject.transform.position = pos + new Vector3(-0.5f,0,0);
                    break;
                case "Left":
                    col.gameObject.transform.position = pos + new Vector3(0.5f,0,0);
                    break;
                case "Up":
                    col.gameObject.transform.position = pos + new Vector3(0,0,-0.5f);
                    break;
                case "Down":
                    col.gameObject.transform.position = pos + new Vector3(0,0,0.5f);
                    break;    
            }
            if(TutorialManager.instance.state == State.spark1)
            {
                TutorialManager.instance.Fadestart();
                TutorialManager.instance.state = State.gate2;
            }
        }
    }
}
