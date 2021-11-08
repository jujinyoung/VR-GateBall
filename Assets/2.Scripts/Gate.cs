using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{   
    [SerializeField]
    GameObject gate;
    public AudioSource audioSource;
    private void Start() {
        audioSource.volume = gameObject.transform.Find("SoundManager").GetComponent<SoundManager>().soundeffect;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("BALL")){
            Debug.Log("부딧힘");
            switch(gate.name){
                case "gate1":
                    if(TutorialManager.instance.state == State.gate1){
                        TutorialManager.instance.state = State.spark1;
                        TutorialManager.instance.Score += 1;
                        audioSource.Play();
                    }
                    break;
                case "gate2":
                    if(TutorialManager.instance.state == State.gate2){
                        TutorialManager.instance.state = State.spark2;
                        TutorialManager.instance.Score += 1;
                        audioSource.Play();
                    }
                    break;
                case "gate3":
                    if(TutorialManager.instance.state == State.gate3){
                        TutorialManager.instance.state = State.GoalPoal;
                        TutorialManager.instance.Score += 1;
                        audioSource.Play();
                    }
                    if(TutorialManager.instance.state == State.spark2){
                        TutorialManager.instance.Score += 1;
                        TutorialManager.instance.state = State.gate3;
                        TutorialManager.instance.Fadestart();
                        audioSource.Play();
                    }
                    break;
                case "pole":
                    if(TutorialManager.instance.state == State.GoalPoal){
                        TutorialManager.instance.Score += 2;
                        TutorialManager.instance.ChangeBoard(TutorialManager.Board.GameEnd);
                    }
                    break;
            }
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "BALL")
        {
            if(gate.name == "pole")
            {
                if(TutorialManager.instance.state == State.GoalPoal)
                {
                    audioSource.Play();
                    TutorialManager.instance.Score += 2;
                    TutorialManager.instance.ChangeBoard(TutorialManager.Board.GameEnd);
                }
            }
        }
    }
}
