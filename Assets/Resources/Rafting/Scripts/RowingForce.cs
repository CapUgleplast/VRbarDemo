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
        }
    }
    // Update is called once per frame
    void Update() {

    }
}
