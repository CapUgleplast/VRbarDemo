using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public bool timerKill;
    public bool colliderKill;
    public double timer;
    void Update() {
        if (timerKill) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                Destroy(this.gameObject);

            }
        }
     
    }
    private void OnTriggerEnter(Collider other) {
        if (colliderKill) {
            Destroy(other.gameObject);
        }
    }
}