using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabAction;   //그랩 액션
    public SteamVR_Action_Boolean rotationAction;
    public SteamVR_Behaviour_Pose controllerPose;

    private GameObject collidingObject = null; //현재 충돌중인 객체
    private GameObject objectHand = null;  //플레이어가 잡은 객체
    private bool grapcheck = false; //물체 잡고 있는 여부

    void Update()
    {
        //잡는 버튼 누를때
        if(grabAction.GetLastStateDown(handType)){
            if(collidingObject)
            {
                if(grapcheck && TutorialManager.instance.grcheck == false){
                    Debug.Log("놓기");
                    ReleaseObject();
                    return;
                }
                GrabObject();
            }
        }
        if(TutorialManager.instance.state == State.spark1 || TutorialManager.instance.state == State.spark2){
            if(rotationAction.GetLastStateDown(handType)){
                TutorialManager.instance.SneakerRotate();
            }
        }

    }

    //충돌시작
    public void OnTriggerEnter(Collider other) {
        SetCollidingObject(other);
    }  
    //충돌중
    public void OnTriggerStay(Collider other) {
        SetCollidingObject(other);
    }
    //충돌끝
    public void OnTriggerExit(Collider other){
        if(!collidingObject){
            return;
        }
        collidingObject = null;
    }  
    
    //충돌중인 객체 설정
    private void SetCollidingObject(Collider col){
        if(collidingObject || !col.GetComponent<Rigidbody>()){
            return;
        }

        collidingObject = col.gameObject;
    }
    //객체 잡음
    private void GrabObject(){
        grapcheck = true;
        objectHand = collidingObject;   //잡은 객체 설정
        collidingObject = null; //충돌 객체 해제

        // objectHand.transform.parent = gameObject.transform;
        // objectHand.transform.position = gameObject.transform.GetChild(2).position;
        // objectHand.transform.rotation = gameObject.transform.GetChild(2).rotation;

        var joint = AddFixedJoint();
        joint.connectedBody = objectHand.GetComponent<Rigidbody>();
        if(TutorialManager.instance.state == State.gameStart && objectHand.tag == "STICK"){
            TutorialManager.instance.state = State.gate1;  
            TutorialManager.instance.Fadestart(); 
        }
    }

    private FixedJoint AddFixedJoint(){
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject(){
        if(GetComponent<FixedJoint>()){
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
        }
        StartCoroutine(GrapCheck());
    }

    IEnumerator GrapCheck(){
        yield return new WaitForSeconds(1.0f);
        grapcheck = false;
        objectHand = null;
    }
}
