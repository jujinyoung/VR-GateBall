using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Haptic : MonoBehaviour
{
    public static Haptic instance = null;
    public SteamVR_Input_Sources hand;
	
    // public SteamVR_Action_Vibration hapticAction;
    private Interactable interactable;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    public void PlayVibration()
    {
        if(interactable.attachedToHand)
        {
            hand = interactable.attachedToHand.handType;
            interactable.attachedToHand.TriggerHapticPulse(1,150,75);
        }
    }
    
    // public void PlayVibration()
    // {
    // 	Pulse(1, 150, 75, SteamVR_Input_Sources.LeftHand);
    //     Pulse(1, 150, 75, SteamVR_Input_Sources.RightHand);
    // }
    
    // private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    // {
        
    //     Execute(0, duration, frequency, amplitude, source);
    //     Debug.Log("Pulse " + source.ToString());
    // }
    


}
