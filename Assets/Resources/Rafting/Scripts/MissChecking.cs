using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MissChecking : MonoBehaviourPun
{
    public int CritDistance;
    private Vector3 startPos;
    private Quaternion startRot;
    public GameObject raft;
    public GameObject HandR;
    public GameObject HandL;
    public Photon.Realtime.Player Owner;
    // Start is called before the first frame update
    void Start()
    {
        HandR = GameObject.FindGameObjectWithTag("HandR");
        HandL = GameObject.FindGameObjectWithTag("HandL");
        startPos = gameObject.transform.localPosition;
        startRot = gameObject.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (LobbyManager.VR && GetComponent<PhotonView>().IsMine) {
            if (HandR.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == false
                && HandL.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == false
                && (gameObject.transform.localPosition.y <= 0
                || Vector3.Distance(transform.localPosition, new Vector3(raft.transform.localPosition.x, raft.transform.localPosition.y, raft.transform.localPosition.z)) > CritDistance)) {
                //Owner = base.photonView.Owner;
                //base.photonView.TransferOwnership(photonView.CreatorActorNr);
                gameObject.transform.localPosition = startPos;
                gameObject.transform.localRotation = startRot;
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                //base.photonView.TransferOwnership(Owner);
            }
        }

        }
    }

