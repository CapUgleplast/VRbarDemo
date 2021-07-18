using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeChop : MonoBehaviour
{

    public Rigidbody axe;
    public double SpeedThreshold;
    public GameObject DustParticles;
    public GameObject Scar;
    public Transform razor;
    public GameObject HandL;
    public GameObject HandR;
    public float freq;
    public float amp;
    public float dur;

    // Start is called before the first frame update
    private void Start() {
       
    }


    // Update is called once per frame
    void Update() {

        
    }

    private void OnCollisionEnter(Collision collision) {
        var smash = collision.transform.GetComponent<AxeHitReaction>();
        if ( smash != null && axe.GetComponent<Rigidbody>().velocity.magnitude >= SpeedThreshold) {
            IEnumerator Haptics(float frequency, float amplitude, float duration, bool rightHand, bool leftHand) {
                if (rightHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
                if (leftHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);

                yield return new WaitForSeconds(duration);

                if (rightHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
                if (leftHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            }
            if (HandR.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == true) {
                StartCoroutine(Haptics(freq, amp, dur, true, false));

            }

            if (HandL.GetComponent<Autohand.Demo.XRHandControllerLink>().grabbingCheck == true) {
                StartCoroutine(Haptics(freq, amp, dur, false, true));

            }
            Instantiate(DustParticles, transform.position, Quaternion.identity);
            smash.Hit();
           // Instantiate(Scar, transform.position, Quaternion.identity);
            //collision.contacts[0].normal
        }
    }
}
