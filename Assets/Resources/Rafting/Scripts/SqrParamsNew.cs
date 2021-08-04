using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
/*
[Serializable]
public struct SpawnerClass
    {
    public static List<Transform> PointsPool;
    
    
    }
*/
public class SqrParamsNew : MonoBehaviour
{
    public List<GameObject> Sqrs;
    public List<GameObject> Obstacles;
    public List<int> ObstacleChance;
    //public List<SpawnerClass> SqrPool;
    public List<Transform> SpawnPool0;
    public List<Transform> SpawnPool1;
    public List<Transform> SpawnPool2;
    public Vector3 SpawnPos;
    
    public float SpawnInterval;
    

    // Start is called before the first frame update
    void Start() {
       
            InvokeRepeating("DoSpawn", 0, SpawnInterval);
            //DoSpawn();
       
    }
    void DoSpawn() {
        int MapChance;
        MapChance = UnityEngine.Random.Range(0, Sqrs.Count);
        var tmpSqr = PhotonNetwork.Instantiate("Rafting/Prefabs/FuncDemo2/" + Sqrs[MapChance].name, SpawnPos, Quaternion.identity);
        //Sqrs[MapChance].SetActive(true);
        tmpSqr.transform.SetParent(p: gameObject.transform);
        int SpawnChance;
        int SpawnPointChance = 0;
        int SpawnTimesChance;

        if (MapChance == 0) {
            for (var i = 0; i < SpawnPool0.Count; i++) {
                SpawnChance = UnityEngine.Random.Range(1, 100);
                if (SpawnChance <= ObstacleChance[i]) {
                    SpawnTimesChance = UnityEngine.Random.Range(1, 4);
                    for (var j = 0; j <= SpawnTimesChance; j++) {
                        SpawnPointChance = UnityEngine.Random.Range(0, SpawnPool0[i].childCount - 1);
                        //SpawnPointChance = UnityEngine.Random.Range(0, SpawnerClass.PointsPool[i]);
                        var tmpObject = PhotonNetwork.Instantiate("Rafting/Prefabs/FuncDemo/" + Obstacles[i].name, SpawnPool0[i].GetChild(SpawnPointChance).transform.position, Quaternion.identity);
                        tmpObject.transform.SetParent(tmpSqr.transform);
                    }
                }
            }
        }
        if (MapChance == 1) {
            for (var i = 0; i < SpawnPool1.Count; i++) {
                SpawnChance = UnityEngine.Random.Range(1, 100);
                if (SpawnChance <= ObstacleChance[i]) {
                    SpawnTimesChance = UnityEngine.Random.Range(1, 4);
                    for (var j = 0; j <= SpawnTimesChance; j++) {
                        SpawnPointChance = UnityEngine.Random.Range(0, SpawnPool1[i].childCount - 1);
                        //SpawnPointChance = UnityEngine.Random.Range(0, SpawnerClass.PointsPool[i]);
                        var tmpObject = PhotonNetwork.Instantiate("Rafting/Prefabs/FuncDemo/" + Obstacles[i].name, SpawnPool1[i].GetChild(SpawnPointChance).transform.position, Quaternion.identity);
                        tmpObject.transform.SetParent(tmpSqr.transform);
                    }
                }
            }
        }
        if (MapChance == 2) {
            for (var i = 0; i < SpawnPool2.Count; i++) {
                SpawnChance = UnityEngine.Random.Range(1, 100);
                if (SpawnChance <= ObstacleChance[i]) {
                    SpawnTimesChance = UnityEngine.Random.Range(1, 4);
                    for (var j = 0; j <= SpawnTimesChance; j++) {
                        SpawnPointChance = UnityEngine.Random.Range(0, SpawnPool2[i].childCount - 1);
                        //SpawnPointChance = UnityEngine.Random.Range(0, SpawnerClass.PointsPool[i]);
                        var tmpObject = PhotonNetwork.Instantiate("Rafting/Prefabs/FuncDemo/" + Obstacles[i].name, SpawnPool2[i].GetChild(SpawnPointChance).transform.position, Quaternion.identity);
                        tmpObject.transform.SetParent(tmpSqr.transform);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update() {
      
        //transform.position += new Vector3(0, 0, SqrSpeed * (-0.01f));
         

        // 

    }
    void FixedUpdate() {

        //GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, -SqrSpeed);
    }
}



