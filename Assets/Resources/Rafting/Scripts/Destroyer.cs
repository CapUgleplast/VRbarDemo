using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public double timer;
    void Update() {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            Destroy(this.gameObject);

        }
    }

}