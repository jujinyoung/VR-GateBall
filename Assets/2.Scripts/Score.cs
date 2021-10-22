using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;   

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    
    void Update()
    {
        scoreText.text= TutorialManager.instance.Score+"";
    }
}
