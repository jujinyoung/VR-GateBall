using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum State{gameStart,gate1,spark1,gate2,spark2,gate3,GoalPoal}

public class TutorialManager : MonoBehaviour
{
    public static  TutorialManager instance = null;
    public State state = State.gameStart;
    public Transform playerpos;
    public Transform ball1,ball2,ball3;
    public GameObject tutorialUI,sparkUI;
    public int Score = 0;
    bool ballinstancecheck = true;
    public Transform arrow;
    [HideInInspector]
    public bool fadecheck = false;  //화면상태 검정 true
    public GameObject sneakers;
    private GameObject sneakerinstance;
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
                    arrow.position = new Vector3(10.2f,2f,-13.5f);
                break;
                case State.gate1:
                    CameraPos(ball1);
                    arrow.position = new Vector3(11.5f,2f,-6f);
                    break;
                case State.spark1:
                    CameraPos(ball1);
                    arrow.position = new Vector3(8,2f,-0.4f);
                    if(ballinstancecheck){
                        Instantiate(ball2,new Vector3(8,0.5f,-0.4f),Quaternion.identity);
                        sparkUI.SetActive(true);
                        ballinstancecheck = false;
                    }
                    break;
                case State.gate2:
                    arrow.gameObject.SetActive(true);
                    arrow.position = new Vector3(-4.4f,2f,7.9f);
                    ballinstancecheck = true;
                    EndSparkAttack();
                break;
                case State.spark2:
                    arrow.position = new Vector3(-1.7f,2f,-7.2f);
                    if(ballinstancecheck){
                        Instantiate(ball3,new Vector3(-1.7f,0.5f,-7.2f),Quaternion.identity);
                        sparkUI.SetActive(true);
                        ballinstancecheck = false;
                    }
                break;
                case State.gate3:
                    arrow.position = new Vector3(0,2f,-8f);
                break;
                case State.GoalPoal:
                    arrow.position = new Vector3(0,2f,0);
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
    public void SparkAttack(GameObject ball1,GameObject ball2, Vector3 pos){
        sneakerinstance = Instantiate(sneakers,pos,Quaternion.identity);
        ball1.transform.parent = sneakerinstance.transform;
        ball2.transform.parent = sneakerinstance.transform;
        ball1.GetComponent<SphereCollider>().enabled = false;
        ball1.GetComponent<Rigidbody>().useGravity = false;
        arrow.gameObject.SetActive(false);
    }
    public void SneakerRotate(){
        float yRotate = sneakerinstance.transform.eulerAngles.y + 45;
        sneakerinstance.transform.rotation = Quaternion.Euler(new Vector3(0,yRotate,0));
    }
    public void EndSparkAttack(){
        ball1.GetComponent<SphereCollider>().enabled = true;
        ball1.GetComponent<Rigidbody>().useGravity = true;
        ball1.transform.parent = null;
        ball1.GetComponent<Ball>().ballspark = true;
        Destroy(sneakerinstance);
    }
}
