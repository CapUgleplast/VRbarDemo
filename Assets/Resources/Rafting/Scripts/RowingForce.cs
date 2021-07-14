using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowingForce : MonoBehaviour
{
    private Vector3 startPoint;
    private Vector3 tmpPoint;
    private Vector3 impulseVector;
    public Rigidbody SqrWorld;
    public int Multiplier;
    public GameObject HandL;
    public GameObject HandR;
    public float freq;
    public float amp;
    // Start is called before the first frame update
    void Start() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Paddle") {
            startPoint = other.transform.position;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Paddle") {
            tmpPoint = other.transform.position;
            impulseVector = (tmpPoint - startPoint);
            SqrWorld.AddForce(impulseVector*Multiplier, ForceMode.Impulse);
            startPoint = tmpPoint;
            if (HandR.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == true) {
                OVRInput.SetControllerVibration(freq, amp, OVRInput.Controller.RTouch);

            }

            if (HandL.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == true) {
                OVRInput.SetControllerVibration(freq, amp, OVRInput.Controller.LTouch);

            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Paddle") {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        }
            // Update is called once per frame
            void Update() {
            
        }
        
    }
}
