using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqrLife : MonoBehaviour
{
    public float SqrSpeed = 0;
    public int DestroyDistance;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * SqrSpeed * -1f * Time.deltaTime);
        if (Vector3.Distance(this.transform.position, startPos) > DestroyDistance) {
            Destroy(gameObject);
            }
        }
    }
