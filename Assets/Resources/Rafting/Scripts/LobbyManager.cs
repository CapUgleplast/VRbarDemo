using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public bool VRBuild;
    public Text LogTextVR;
    public Text LogText;
    public GameObject VRLobby;
    public GameObject Lobby;
    public Text PCplayersVR;
    public Text VRplayersVR;
    public Text PCplayers;
    public Text VRplayers;
    public GameObject StartButton;
    public static bool VR;
    
    // Start is called before the first frame update
    void Start() {
        VR = VRBuild;
        if (!VR) {
            PhotonNetwork.NickName = "FcknSlave" + Random.Range(10, 100);
        }
        else {
            PhotonNetwork.NickName = "VR_FcknSlave" + Random.Range(10, 100);
        }
        Log("Player's name " + PhotonNetwork.NickName);
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster() {
        Log("Connected to Master");
    }

    public void CreateRoom() {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 4 });
    }

    public void LetsGo() {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        PhotonNetwork.LoadLevel(1);
    }
    public void JoinRoom() {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom() {
        Log("Joined the Room");
        Lobby.SetActive(true);
        VRLobby.SetActive(true);
        if(!VR) {
            PCplayers.text += "\n";
            PCplayers.text += PhotonNetwork.NickName;
           
           
        }
        else {
            PCplayersVR.text += "\n";
            PCplayersVR.text += PhotonNetwork.NickName;
        }
        
        
    }

    private void Log(string message) {
        Debug.Log(message);
        LogText.text += "\n";
        LogText.text += message;
        LogTextVR.text += "\n";
        LogTextVR.text += message;
        
    }
    // Update is called once per frame
    void Update() {
         if (PhotonNetwork.PlayerList.Length > 1) {
                StartButton.SetActive(true);
            }
            
        
        if (Lobby.activeInHierarchy == true || VRLobby.activeInHierarchy == true) {
            if (!VR)
                VRplayers.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
            else
                VRplayersVR.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
        }
    }
}
