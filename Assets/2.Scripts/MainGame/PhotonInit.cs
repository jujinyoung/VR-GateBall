using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PhotonInit : MonoBehaviourPunCallbacks
{
    public enum ActivePanel{Start,Game}
    private string gameVersion = "1.0";
    public byte maxPlayer = 2;
    public GameObject[] panels;
    public GameObject room;
    public Transform gridTr;
    bool check = false;
    // Start is called before the first frame update
    void Awake()
    {
        // Screen.SetResolution(1280,720,false);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();              //OnJoinedLobby()콜백함수 
        check = true;
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room!!!");
        PhotonNetwork.IsMessageQueueRunning = false;
        SceneManager.LoadScene("MainGame");
    }

    public void OnLogin()
    {
        Debug.Log("로그인실행");
        PhotonNetwork.GameVersion = this.gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        ChangePanel(ActivePanel.Game);
    }

    void ChangePanel(ActivePanel panel)
    {
        foreach(GameObject _panel in panels)
        {
            _panel.SetActive(false);
        }
        panels[(int)panel].SetActive(true);
    }

    public void OnCreateRoomClick()
    {
        if(check == true)
        {
            PhotonNetwork.CreateRoom("", new RoomOptions{MaxPlayers = this.maxPlayer});
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        // foreach(GameObject obj in GameObject.FindGameObjectsWithTag("ROOM"))
        // {
        //     Destroy(obj);
        // }
        foreach(RoomInfo roomInfo in roomList)
        {
            Debug.Log("실행");
            GameObject _room = Instantiate(room, gridTr);
            _room.GetComponent<Button>().onClick.AddListener
            (
                delegate
                {
                    OnClickRoom();
                }
            );
        }
    }

    void OnClickRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void Backspace()
    {
        PhotonNetwork.Disconnect();
        ChangePanel(ActivePanel.Start);
    }
}
