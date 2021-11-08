using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public float backgroundsound;
    public float soundeffect;
    public enum screen{game,setting}
    public GameObject[] panels;
    public Slider backgoundslider, effectslider;
    AudioSource audioSource;


    private void Awake() {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }    
    

    public void Changepanel(screen panel)
    {
        foreach(GameObject _panel in panels){
            _panel.SetActive(false);
        }
        panels[(int)panel].SetActive(true);
    }
    
    public void SettingClick()
    {
        Changepanel(screen.setting);
    }

    public void BackToGame(){
        Changepanel(screen.game);
    }

    private void Update() {
        backgroundsound = backgoundslider.GetComponent<Slider>().value;
        soundeffect = effectslider.GetComponent<Slider>().value;
        // background = transform.Find("[CameraRig]").gameObject;
        // background.GetComponent<AudioSource>().volume = backgroundsound;
        audioSource.volume = backgroundsound;
    }
}
