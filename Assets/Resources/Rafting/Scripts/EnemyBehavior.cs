using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 tmpPos;
    private bool isLoaded = false;
    private GameObject HeldObj;
    public bool isFree = true;
    public bool isReadyToLeap = false;
    public float Speed = 3;
    public int index;
    private float OctoCalm = 0;

    // Start is called before the first frame update
    void Start() {

    }

    private void OnTriggerStay(Collider other) {
        
        if (other.tag == "Crab") {
            isFree = false;
            if (Hinput.gamepad[index].A.justPressed && !isLoaded) {
                HeldObj = other.gameObject;
                other.transform.SetParent(this.transform);
                other.transform.localPosition = Vector3.zero;
                isLoaded = true;
            }
        }
        if (other.tag == "Raft") {
            isFree = false;
            if (Hinput.gamepad[index].A.justPressed && isLoaded) {
                HeldObj.transform.SetParent(other.transform);
                float xCrab;
                float zCrab;
                int axisCrab = Random.Range(0, 1);
                if (axisCrab > 0.5f) {
                    zCrab = Random.Range(0, 1);
                    if(zCrab > 0.5f) {
                        zCrab = 1.59f;
                    }
                    else {
                        zCrab = -1.59f;
                    }
                    xCrab = Random.Range(-0.76f, 0.76f);
                }
                else {
                    xCrab = Random.Range(0, 1);
                    if (xCrab > 0.5f) {
                        xCrab = 0.76f;
                    }
                    else {
                        xCrab = -0.76f;
                    }
                    zCrab = Random.Range(-1.59f, 1.59f);
                }
                HeldObj.transform.localPosition = Vector3.zero + new Vector3(xCrab, 0, zCrab);
                isLoaded = false;
            }
        }
        if (other.tag == "Octopus") {
            isFree = false;
            
            if (OctoCalm > 0 && OctoCalm < 4) {
                OctoCalm -= Time.deltaTime;
            }
            if (Hinput.gamepad[index].A.justPressed) {
                OctoCalm += 0.6f;
            }
            if (OctoCalm >= 4) {
                other.transform.position += new Vector3(0, 5, 0);
                OctoCalm = 0;
            }
        }
        if (other.tag == "Paddle") {
            Vector2 stickPosition = Hinput.gamepad[index].leftStick;
            Vector3 LeapDir = new Vector3(-stickPosition.y, 0.2f, stickPosition.x);
            gameObject.GetComponent<Rigidbody>().AddForce(LeapDir, ForceMode.Impulse);
        }

        }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Crab") {
            isFree = true;
        }
        if (other.tag == "Raft") {
            isFree = true;
        }
        if (other.tag == "Octopus") {
            isFree = true;
        }
    }



            // Update is called once per frame
            void Update() {

        

        Vector2 stickPosition = Hinput.gamepad[index].leftStick;
            if (transform.position.y < 0 && !isReadyToLeap) {
           
            transform.position += new Vector3(stickPosition.y, 0, -stickPosition.x) * Speed * Time.deltaTime;
            if (Mathf.Abs(stickPosition.x) > 0.5f || Mathf.Abs(stickPosition.y) > 0.5f) {
                Vector3 relativePos = new Vector3(stickPosition.x, 0f, stickPosition.y);
                Quaternion targetRot = Quaternion.LookRotation(relativePos);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 2f);
            }

        }
            Vector3 LeapDir = new Vector3(stickPosition.y, 0.7f, -stickPosition.x);
            if (isFree && !isLoaded && Hinput.gamepad[index].A.longPress) {
                isReadyToLeap = true;
            if (Mathf.Abs(stickPosition.x) > 0.5f || Mathf.Abs(stickPosition.y) > 0.5f) {
                Vector3 relativePos = new Vector3(stickPosition.x, 0f, stickPosition.y);
                Quaternion targetRot = Quaternion.LookRotation(relativePos);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 2f);
            }

        }
            if (transform.position.y < 0 && isFree && !isLoaded && Hinput.gamepad[index].A.justReleased) {
                gameObject.GetComponent<Rigidbody>().AddForce(LeapDir*20, ForceMode.Impulse);
            Invoke("LeapDelay", 2);
            }
        
    }
    void LeapDelay() {
        isReadyToLeap = false;
    }
}
