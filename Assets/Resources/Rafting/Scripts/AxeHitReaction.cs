using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHitReaction : MonoBehaviour
{
    private double AxeVelocity;
    public Rigidbody axe;
    private double AxeSpeed;
    public int SpeedThreshold;
    public GameObject destroyable;

    private void OnTriggerEnter(Collider other) {
       if(other.tag == "Axe" && AxeSpeed >= SpeedThreshold) {
            
            Destroy(destroyable);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AxeSpeed = axe.GetComponent<Rigidbody>().velocity.magnitude;
    }
}
