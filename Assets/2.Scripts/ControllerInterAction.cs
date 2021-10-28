using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ControllerInterAction : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean interAction;
    public Transform dot;
    [HideInInspector]
    public bool actionCheck = true;
    
   private void Update() {
        RaycastHit hit;
        if (Physics.Raycast(controllerPose.transform.position,controllerPose.transform.forward,out hit,15f)){
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI")){
                actionCheck = false;
                dot.gameObject.SetActive(true);
                dot.position = hit.point;
            }
            else{
                dot.gameObject.SetActive(false);
                actionCheck = true;
            }  
            if(dot.gameObject.activeSelf){
                if(interAction.GetStateDown(handType)){
                    Button btn = hit.transform.GetComponent<Button>();
                    if(btn != null){
                        btn.onClick.Invoke();
                    }
                }
            }
        }
        // else{
        //     dot.gameObject.SetActive(false);
        // }
    }
}
