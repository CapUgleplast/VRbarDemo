using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public int index;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Hinput.gamepad[index].A.justPressed) {
            GetComponent<Renderer>().material.color = Color.red;
        }

        Vector2 stickPosition = Hinput.gamepad[index].leftStick;
        transform.position += new Vector3(stickPosition.y, 0, -stickPosition.x) * speed * Time.deltaTime;
        //transform.position = new Vector3( stickPosition.x = (transform.position.x), 0 , 0) * speed * Time.deltaTime;
        //transform.position = new Vector3(0, stickPosition.y = (transform.position.y), 0) * speed * Time.deltaTime;

    }
}

