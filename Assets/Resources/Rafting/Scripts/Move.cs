using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Hinput.gamepad[1].A.justPressed) {
            GetComponent<Renderer>().material.color = Color.red;
        }

        
        //transform.position = new Vector3( stickPosition.x = (transform.position.x), 0 , 0) * speed * Time.deltaTime;
        //transform.position = new Vector3(0, stickPosition.y = (transform.position.y), 0) * speed * Time.deltaTime;

    }
}

