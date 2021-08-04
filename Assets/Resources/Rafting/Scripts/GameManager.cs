using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject Ape;
    public GameObject Fish;
    public GameObject Raft;
    private bool VRbuild;
    public GameObject OVRcontroller;
    private GameObject raftParent;
    public GameObject SqrSpawner;
    public GameObject StartPanel;
    public GameObject StartPanelVR;
    private PhotonView PV;
    private float time = 5;
    private bool NotReady = true;
    public Text InfoT;
    public Text InfoVR;

    private bool VRsHere = false;



    public void Awake() {
        PV = GetComponent<PhotonView>();
        VRbuild = LobbyManager.VR;
        Update();
    }




    // Start is called before the first frame update
    void StartGame() {

        StartPanel.SetActive(false);
        StartPanelVR.SetActive(false);



        if (!VRbuild) {
            SqrSpawner.SetActive(true);
            //raftParent = PhotonNetwork.Instantiate("Rafting/Prefabs/FuncDemo2/" + Raft.name, new Vector3(0, -0.42f, 0), Quaternion.identity);
            //PV.RPC("RPC_VRparent", RpcTarget.All, raftParent, OVRcontroller);
            //OVRcontroller.transform.SetParent(raftParent.transform);
            var j = Random.Range(1, 2);

            if (j == 1) {
                PhotonNetwork.Instantiate("Rafting/Prefabs/FuncDemo2/" + Ape.name, new Vector3(-30, 1, 30), Quaternion.identity);

            }
            else if (j == 2) {
                PhotonNetwork.Instantiate("Rafting/Prefabs/FuncDemo2/" + Fish.name, new Vector3(-9, 0, 28), Quaternion.identity);

            }
        }
        else if (VRbuild) {
            if (PhotonNetwork.PlayerListOthers.Length == 1) {
                //raftParent = PhotonView.Find(1001).gameObject;
               // raftParent = GameObject.FindGameObjectWithTag("Raft");
                //PV.RPC("RPC_VRparent", RpcTarget.All, raftParent);
                raftParent = PhotonNetwork.Instantiate("Rafting/Prefabs/FuncDemo2/" + Raft.name, new Vector3(0, -0.42f, 0), Quaternion.identity);
                OVRcontroller.transform.SetParent(raftParent.transform);
                VRsHere = true;
            }
            else {
                raftParent = GameObject.FindWithTag("Raft");
                OVRcontroller.transform.SetParent(raftParent.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (VRbuild) {
            if (raftParent == null) {
                //raftParent = PhotonView.Find(1001).gameObject;
                raftParent = GameObject.FindGameObjectWithTag("Raft");
                //PV.RPC("RPC_VRparent", RpcTarget.All, raftParent);

                OVRcontroller.transform.SetParent(raftParent.transform);
                VRsHere = true;
            }
        }*/
        if (NotReady == true && !VRbuild) {
            time -= Time.deltaTime;
            InfoT.text = time.ToString();
            InfoVR.text = time.ToString();
            if (time <= 0) {
                NotReady = false;
                PV.RPC("RPC_Wait", RpcTarget.All);
               
            }
        }
    }
    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom() {
        SceneManager.LoadScene(0);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.LogFormat("Player {0} has entered the room", newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {
        Debug.LogFormat("Player {0} has left the room", otherPlayer.NickName);
    }



    [PunRPC]
    void RPC_VRparent(GameObject raftParent) {
        OVRcontroller.transform.SetParent(raftParent.transform);
        Debug.Log("parent");
    }
    [PunRPC]
    void RPC_Wait() {
        StartGame();
        
    }
}
