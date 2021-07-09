using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public bool FixPoint1 = false;
    public bool FixPoint2 = false;
    public GameObject Breakdown;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "FixPoint1") {
            FixPoint1 = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "FixPoint2") {
            FixPoint2 = true;
            Destroy(other.gameObject);
        }

    }
    void Update() {
        if (FixPoint1 == true && FixPoint2 == true){
            Destroy(Breakdown);
        }
    }
}