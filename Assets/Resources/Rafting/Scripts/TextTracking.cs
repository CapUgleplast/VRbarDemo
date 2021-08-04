using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class TextTracking : MonoBehaviour, IPunObservable
{
    public Text text;
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text = GetComponent<Text>();
    }
}
