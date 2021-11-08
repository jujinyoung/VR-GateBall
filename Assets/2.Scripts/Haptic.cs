using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Haptic : MonoBehaviour
{
	
    public SteamVR_Action_Vibration hapticAction;
    
    public void PlayVibration()
    {
    	Pulse(0.5f, 30, 15, SteamVR_Input_Sources.LeftHand);
        Pulse(0.5f, 30, 15, SteamVR_Input_Sources.RightHand);
    }
    
    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
        Debug.Log("Pulse " + source.ToString());
    }
}