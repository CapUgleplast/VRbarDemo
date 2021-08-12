using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftParent : MonoBehaviour
{
    public GameObject raftParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        raftParent = GameObject.FindWithTag("Raft");
        //raftParent = PhotonView.Find(1001).gameObject;
        raftParent = GameObject.FindGameObjectWithTag("Raft");
        //PV.RPC("RPC_VRparent", RpcTarget.All, raftParent);
        Debug.Log("parent");
        this.transform.SetParent(raftParent.transform);
        //VRsHere = true;
    
}
}
