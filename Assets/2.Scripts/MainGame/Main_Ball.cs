using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team{red,white}
public enum BallState{gate1,gate2,gate3,pole}
public class Main_Ball : MonoBehaviour
{
    public Team team;
    public BallState ballState = BallState.gate1;
    
    private void Start() {
        
    }
}
