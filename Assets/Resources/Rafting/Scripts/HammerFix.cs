using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  HammerFix : MonoBehaviour
{
    public bool FixPoint1 = false;
    public bool FixPoint2 = false;
    public bool FixPoint3 = false;
    public bool FixPoint4 = false;
    public GameObject HandL;
    public GameObject HandR;
    public GameObject Breakdown;
    public bool grabCheckR;
    public float freq;
    public float amp;
    public float dur;

    private void OnTriggerEnter(Collider other) {

        IEnumerator Haptics(float frequency, float amplitude, float duration, bool rightHand, bool leftHand) {
            if (rightHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
            if (leftHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);

            yield return new WaitForSeconds(duration);

            if (rightHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            if (leftHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        }

        if (other.tag == "FixPoint1") {
            FixPoint1 = true;
            Destroy(other.gameObject);
            if(HandR.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == true){
                StartCoroutine(Haptics(freq, amp, dur, true, false));
                
             }

            if (HandL.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == true) {
                StartCoroutine(Haptics(freq, amp, dur, false, true));

            }
        
        }
        if (other.tag == "FixPoint2") {
            FixPoint2 = true;
            Destroy(other.gameObject);
            if (HandR.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == true) {
                StartCoroutine(Haptics(freq, amp, dur, true, false));

            }

            if (HandL.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == true) {
                StartCoroutine(Haptics(freq, amp, dur, false, true));

            }

        }
        if (other.tag == "FixPoint3") {
            FixPoint3 = true;
            Destroy(other.gameObject);
            if (HandR.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == true) {
                StartCoroutine(Haptics(freq, amp, dur, true, false));

            }

            if (HandL.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == true) {
                StartCoroutine(Haptics(freq, amp, dur, false, true));

            }
        }
        if (other.tag == "FixPoint4") {
            FixPoint4 = true;
            Destroy(other.gameObject);
            if (HandR.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == true) {
                StartCoroutine(Haptics(freq, amp, dur, true, false));

            }

            if (HandL.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == true) {
                StartCoroutine(Haptics(freq, amp, dur, false, true));

            }

        }

        }
    void Update() {
        if (FixPoint1 == true && FixPoint2 == true && FixPoint3 == true && FixPoint4 == true) {
            Destroy(Breakdown);
            FixPoint1 = false;
            FixPoint2 = false;
            FixPoint3 = false;
            FixPoint4 = false;
}
        
    }
}