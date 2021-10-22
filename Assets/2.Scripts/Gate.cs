using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{   
    bool check = true;
    [SerializeField]
    GameObject gate;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("BALL")){
            switch(gate.name){
                case "gate1":
                    if(TutorialManager.instance.state == State.gate1){
                        StartCoroutine(CollideGate(State.gate2));
                        TutorialManager.instance.Score += 1;
                    }
                    break;
                case "gate2":
                    if(TutorialManager.instance.state == State.gate2){
                        StartCoroutine(CollideGate(State.gate3));
                        TutorialManager.instance.Score += 1;
                    }
                    break;
                case "gate3":
                    if(TutorialManager.instance.state == State.gate3){
                        StartCoroutine(CollideGate(State.GoalPoal));
                        TutorialManager.instance.Score += 1;
                    }
                    break;
                case "GoalPoal" :
                    if(TutorialManager.instance.state == State.GoalPoal){
                        TutorialManager.instance.Score += 2;
                    }
                    break;
            }
        }
    }

    IEnumerator CollideGate(State state){
        yield return new WaitForSeconds(2.0f);
        TutorialManager.instance.state = state;
        TutorialManager.instance.Fadestart();
    }
}
