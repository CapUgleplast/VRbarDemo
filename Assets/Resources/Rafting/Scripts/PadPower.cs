using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadPower : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Crab") {
            Destroy(other.gameObject);
        }
        if(other.tag == "Fish") {
            var startPos = other.transform.position;
            other.GetComponent<Rigidbody>().AddForce((startPos - other.transform.position)*15, ForceMode.Impulse);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
