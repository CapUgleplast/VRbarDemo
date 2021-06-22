using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqrSpawn : MonoBehaviour
{
    public int SpawnSqrChance;
    public int SqrNum;
    private void Start() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            SpawnSqrChance = Random.Range(1, SqrNum + 1);
            var SQRmap = Resources.Load<GameObject>("Rafting/Prefabs/FuncDemo/ExmpSQR" + SpawnSqrChance);

            //Instantiate(SqrSpawn[SpawnSqrChance], new Vector3(0, 0, 47), Quaternion.identity);
            Instantiate(SQRmap, new Vector3(0, 0, 45), Quaternion.identity);
        }
    }
}