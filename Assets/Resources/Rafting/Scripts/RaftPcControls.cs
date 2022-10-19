using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaftPcControls : MonoBehaviour
{

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.002f, 0, 0); 
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.002f, 0, 0); 
        }
    }
}
