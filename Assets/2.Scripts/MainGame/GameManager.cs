using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static  GameManager instance = null;
    [HideInInspector]
    public int redScore;
    [HideInInspector]
    public int whiteScore;
    public Transform arrow;
    public GameObject Player;
    public GameObject[] balls;
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
        Invoke("CharacterInit", 1.0f);
        PhotonNetwork.IsMessageQueueRunning = true;
    }

    void CharacterInit(){
        GameObject player = Instantiate(Player);
        player.transform.position = new Vector3(0,0,0);

        //네트워크 오브젝트 설정
        GameObject punObject = PhotonNetwork.Instantiate("PunObject",new Vector3(9.688f,0,-13.702f),Quaternion.identity);
        punObject.transform.parent = GameObject.Find("[CameraRig2]").transform;

        //위치 설정
        punObject.transform.Find("LeftHand").transform.parent = player.transform.Find("Controller (left)").transform;
        punObject.transform.Find("RightHand").transform.parent = player.transform.Find("Controller (right)").transform;
    }

    void BallTurn(GameObject ball)
    {
        foreach(GameObject _ball in balls)
        {
            _ball.GetComponent<SphereCollider>().enabled = false;
            _ball.GetComponent<Rigidbody>().useGravity = false;
        }
        ball.GetComponent<SphereCollider>().enabled = true;
        ball.GetComponent<Rigidbody>().useGravity = true;
    }
}
