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
    public GameObject raftParent;
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
            raftParent = PhotonNetwork.Instantiate("Rafting/Prefabs/FuncDemo2/" + Raft.name, new Vector3(0, -0.42f, 0), Quaternion.identity);
            //PV.RPC("RPC_VRparent", RpcTarget.Others, raftParent);
            //OVRcontroller.transform.SetParent(raftParent.transform);
            
               //PhotonNetwork.Instantiate("Rafting/Prefabs/FuncDemo2/" + Ape.name, new Vector3(-30, 1, 10), Quaternion.identity);

           
                PhotonNetwork.Instantiate("Rafting/Prefabs/FuncDemo2/" + Fish.name, new Vector3(-9, 0, 8), Quaternion.identity);

            
        }
        else if (VRbuild) {
            if (VRsHere == false) {
                //raftParent = PhotonView.Find(1001).gameObject;
                // raftParent = GameObject.FindGameObjectWithTag("Raft");
                //PV.RPC("RPC_VRparent", RpcTarget.All, raftParent);
                // PV.RPC("RPC_VRparent", RpcTarget.All, VRsHere);
                raftParent = GameObject.FindWithTag("Raft");
                //raftParent = PhotonNetwork.Instantiate("Rafting/Prefabs/FuncDemo2/" + Raft.name, new Vector3(0, -0.42f, 0), Quaternion.identity);
                //OVRcontroller.transform.SetParent(raftParent.transform);
                //PV.RPC("RPC_VRparent", RpcTarget.All, VRsHere);
                //VRsHere = true;
            }
            else if (VRsHere == true) {
               // raftParent = GameObject.FindWithTag("Raft");
                //OVRcontroller.transform.SetParent(raftParent.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (VRbuild && NotReady == false) {
            raftParent = GameObject.FindWithTag("Raft");
            //raftParent = PhotonView.Find(1001).gameObject;
            raftParent = GameObject.FindGameObjectWithTag("Raft");
            //PV.RPC("RPC_VRparent", RpcTarget.All, raftParent);
            Debug.Log("parent");
            OVRcontroller.transform.SetParent(raftParent.transform);
                //VRsHere = true;
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
        //VRsHere = true;
        
        OVRcontroller.transform.SetParent(raftParent.transform);
        //base.photonView.RequestOwnership();
        //Debug.Log("parent");
    }
    [PunRPC]
    void RPC_Wait() {
        StartGame();
        
    }
}
