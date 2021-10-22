using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum State{gameStart,gate1,gate2,gate3,GoalPoal}

public class TutorialManager : MonoBehaviour
{
    public static  TutorialManager instance = null;
    public State state = State.gameStart;
    public Transform playerpos;
    public Transform ball1,ball2,ball3;
    public GameObject tutorialUI,sparkUI;
    public int Score = 0;
    bool ballinstancecheck = true;
    [HideInInspector]
    public bool fadecheck = false;  //화면상태 검정 true
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        playerpos.position = new Vector3(9.688f,0,-13.702f);
    }
    private void Update() {
        if(fadecheck){
            switch(state){
                case State.gameStart:
                break;
                case State.gate1:
                    CameraPos(ball1);
                    break;
                case State.gate2:
                    CameraPos(ball1);
                    if(ballinstancecheck){
                        Instantiate(ball2,new Vector3(8,0.5f,-0.4f),Quaternion.identity);
                        Instantiate(ball3,new Vector3(9.4f,0.5f,-1f),Quaternion.identity);
                        sparkUI.SetActive(true);
                        ballinstancecheck = false;
                    }
                    break;
                case State.gate3:
                break;
            }

        }
    }

    public void Fadestart(){
        FadeInOut.instance.Fadeflow();
    }

    private void CameraPos(Transform obj){
        Vector3 pos = playerpos.position;
        pos.x = obj.position.x;
        pos.z = obj.position.z;
        playerpos.position = pos;
        fadecheck = false;
    }

    public void WindowExit(){
        tutorialUI.SetActive(false);
        sparkUI.SetActive(false);
    }
}
