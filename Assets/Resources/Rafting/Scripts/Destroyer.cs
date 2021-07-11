using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public bool FixPoint1 = false;
    public bool FixPoint2 = false;
    public GameObject HandL;
    public GameObject HandR;
    public GameObject Breakdown;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "FixPoint1") {
            FixPoint1 = true;
            Destroy(other.gameObject);
           /* if (HandR.GetComponent<XRHandControllerLink>().grabbingCheck == true) {
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
            }

            if (HandL.GetComponent<XRHandControllerLink>().grabbingCheck == true) {
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
          
            }
        */
        }
        if (other.tag == "FixPoint2") {
            FixPoint2 = true;
            Destroy(other.gameObject);
           /* if (HandR.GetComponent<XRHandControllerLink>().grabbingCheck == true) {
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
            }

            if (HandL.GetComponent<XRHandControllerLink>().grabbingCheck == true) {
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);

            }*/

        }

    }
    void Update() {
        if (FixPoint1 == true && FixPoint2 == true){
            Destroy(Breakdown);
        }
    }
}