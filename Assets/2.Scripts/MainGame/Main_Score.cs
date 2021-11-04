using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;   

public class Main_Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI redScore;
    [SerializeField]
    private TextMeshProUGUI whiteScore;
    
    void Update()
    {
        redScore.text = GameManager.instance.redScore + "";
        whiteScore.text = GameManager.instance.whiteScore + "";
    }
}
