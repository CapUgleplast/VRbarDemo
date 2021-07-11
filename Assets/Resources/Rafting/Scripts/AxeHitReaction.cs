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
    public GameObject DustParticles;
    public GameObject Scar;
    public int HP;

    private void OnTriggerEnter(Collider other) {
       if(other.tag == "Axe" && AxeSpeed >= SpeedThreshold) {
            Instantiate(DustParticles, other.transform.position, Quaternion.identity);
            HP = HP - 1;
            if (HP <= 0) {
                Destroy(destroyable);
            }
            Instantiate(Scar, other.transform.position, other.transform.rotation);
            
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
