using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqrSpawn : MonoBehaviour
{
    public int SpawnSqrChance;
    public int SqrNum;
    public GameObject SqrSpawnPoint;
    //public GameObject SqrMagnet;
  // private GameObject SQRmap;
    private void Start() {
        SqrSpawnPoint = GameObject.Find("SqrSpawnPoint");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            SpawnSqrChance = Random.Range(1, SqrNum + 1);
            Debug.Log(SpawnSqrChance);
            var SQRmap = Resources.Load<GameObject>("Rafting/Prefabs/FuncDemo/ExmpSQR" + SpawnSqrChance);
            
            //Instantiate(SqrSpawn[SpawnSqrChance], new Vector3(0, 0, 47), Quaternion.identity);
            //Instantiate(SQRmap, new Vector3(0, 0, 45), Quaternion.identity);
            Instantiate(SQRmap, SqrSpawnPoint.transform);
            Destroy(this.gameObject);
        }
       
        }
    private void Update() {
       // SqrMagnet = GameObject.Find("SqrSpawnPoint/ExmpSQR" + SpawnSqrChance + "/SqrSpawnPos");
        //SQRmap.transform.position = SqrMagnet.transform.position;

    }
}