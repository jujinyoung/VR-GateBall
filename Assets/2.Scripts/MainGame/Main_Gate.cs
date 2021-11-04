using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Gate : MonoBehaviour
{
    [SerializeField]
    GameObject gate;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("BALL")){
            switch(gate.name){
                case "gate1":
                    if(other.GetComponent<Main_Ball>().ballState == BallState.gate1){
                        if(other.GetComponent<Main_Ball>().team == Team.red)
                        {
                            GameManager.instance.redScore++;
                        }else
                        {
                            GameManager.instance.whiteScore++;
                        }
                        other.GetComponent<Main_Ball>().ballState = BallState.gate2;
                    }
                    break;
                case "gate2":
                    if(other.GetComponent<Main_Ball>().ballState == BallState.gate2){
                        if(other.GetComponent<Main_Ball>().team == Team.red)
                        {
                            GameManager.instance.redScore++;
                        }else
                        {
                            GameManager.instance.whiteScore++;
                        }
                        other.GetComponent<Main_Ball>().ballState = BallState.gate3;
                    }
                    break;
                case "gate3":
                    if(other.GetComponent<Main_Ball>().ballState == BallState.gate3){
                        if(other.GetComponent<Main_Ball>().team == Team.red)
                        {
                            GameManager.instance.redScore++;
                        }else
                        {
                            GameManager.instance.whiteScore++;
                        }
                        other.GetComponent<Main_Ball>().ballState = BallState.pole;
                    }
                    break;
                case "pole" :
                    if(other.GetComponent<Main_Ball>().ballState == BallState.pole){
                        if(other.GetComponent<Main_Ball>().team == Team.red)
                        {
                            GameManager.instance.redScore+=2;
                        }else
                        {
                            GameManager.instance.whiteScore+=2;
                        }
                        Destroy(other,1f);
                    }
                    break;
            }
        }
    }
}
