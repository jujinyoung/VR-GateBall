using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;


public class ControllerTelePort : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean teleportAction;

    public GameObject lazerPrefab;
    private GameObject lazer;
    private Transform lazerTransform;
    private Vector3 hitPoint;   //레이저 부딪친 부분

    public Transform cameraRigTransform;
    public GameObject teleportReticlePrefab;
    private GameObject reticle;
    private Transform teleportReticleTransform;
    public Transform headTransform;
    public Vector3 teleportReticleOffset;   
    public LayerMask teleportMask;  //텔포 허용 레이어 마스크
    private bool shouldTeleport;    //텔포 가능여부

    void Start()
    {  
        lazer = Instantiate(lazerPrefab);    
        lazerTransform = lazer.transform;

        reticle = Instantiate(teleportReticlePrefab);
        teleportReticleTransform = reticle.transform;
        reticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(teleportAction.GetState(handType)){
            RaycastHit hit;

            if(Physics.Raycast(controllerPose.transform.position,transform.forward,out hit,100,teleportMask)){
                hitPoint = hit.point;
                ShowLazer(hit);
                reticle.SetActive(true);
                teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                shouldTeleport = true;
            }
        }
        else{
            lazer.SetActive(false);
        }

        if(teleportAction.GetStateUp(handType)&&shouldTeleport){
            Teleport();
        }
    }

    //레이저 보여주기
    public void ShowLazer(RaycastHit hit){
        lazer.SetActive(true);
        lazer.transform.position = Vector3.Lerp(controllerPose.transform.position,hitPoint,0.5f);
        lazerTransform.LookAt(hitPoint);
        lazerTransform.localScale = new Vector3(lazerTransform.localScale.x,lazerTransform.localScale.y,hit.distance);
    }

    private void Teleport(){
        shouldTeleport = false;
        reticle.SetActive(false);
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;
        cameraRigTransform.position = hitPoint+difference;
    }
}
