using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftDrag : MonoBehaviour
{
    public Vector3 startRaftPoint;
    public ConstantForce drag;
    // Start is called before the first frame update
    void Start()
    {
        drag = GetComponent<ConstantForce>();
        startRaftPoint = transform.position;
    }

    // Update is called once per frame
    void Update() {
        //drag.force = new Vector3(0,0, -1);
        if (Vector3.Distance(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, startRaftPoint.z)) > 1) {
            if (transform.position.z - startRaftPoint.z > 0) {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
            }
            else if (transform.position.z - startRaftPoint.z < 0) {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
            }
        }
        else {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
