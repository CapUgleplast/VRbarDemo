using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqrParams : MonoBehaviour
{
    public GameObject tree;
    public GameObject stone;
    public GameObject deer;
    public GameObject rock;
    public GameObject swirl;
    public GameObject rapid;
    public GameObject octopus;
    public GameObject crab;
    

    public List<Transform> treeSpawn;
    public List<Transform> stoneSpawn;
    public List<Transform> deerSpawn;
    public List<Transform> rockSpawn;
    public List<Transform> swirlSpawn;
    public List<Transform> rapidSpawn;
    public List<Transform> octopusSpawn;
    public List<Transform> crabSpawn;


    public bool treeON = false;
    public bool stoneON = false;
    public bool deerON = false;
    public bool rockON = false;
    public bool swirlON = false;
    public bool rapidON = false;
    public bool octopusON = false;
    public bool crabON = false;

    public int TreeChance;
    public int StoneChance;
    public int DeerChance;
    public int RockChance;
    public int SwirlChance;
    public int RapidChance;
    public int OctopusChance;
    public int CrabChance;

    public int SqrSpeed = 0;

    public int DestroyDistance;

    // Start is called before the first frame update
    void Start() {
        int SpawnChance;
        for (var i = 0; i < 8; i++) {
            SpawnChance = Random.Range(1, 100);
            if (i == 0 && SpawnChance <= TreeChance)
                treeON = true;
            if (i == 1 && SpawnChance <= StoneChance)
                stoneON = true;
            if (i == 2 && SpawnChance <= DeerChance)
                deerON = true;
            if (i == 3 && SpawnChance <= RockChance)
                rockON = true;
            if (i == 4 && SpawnChance <= SwirlChance)
                swirlON = true;
            if (i == 5 && SpawnChance <= RapidChance)
                rapidON = true;
            if (i == 6 && SpawnChance <= OctopusChance)
                octopusON = true;
            if (i == 7 && SpawnChance <= CrabChance)
                crabON = true;
        }

        int SpawnPointChance;
        if (treeON == true) {
            SpawnPointChance = Random.Range(0, treeSpawn.Count - 1);
            Instantiate(tree, treeSpawn[SpawnPointChance]);
        }
        if (stoneON == true) {
            for (int i = 0; i < Random.Range(3, stoneSpawn.Count); i++) {
                SpawnPointChance = Random.Range(0, stoneSpawn.Count - 1);
                Instantiate(stone, stoneSpawn[SpawnPointChance]);
            }
        }
        if (deerON == true) {
            SpawnPointChance = Random.Range(0, deerSpawn.Count - 1);
            Instantiate(deer, deerSpawn[SpawnPointChance]);
        }
        if (rockON == true) {
            for (int i = 0; i < Random.Range(3, rockSpawn.Count); i++) {
                SpawnPointChance = Random.Range(0, rockSpawn.Count - 1);
                Instantiate(rock, rockSpawn[SpawnPointChance]);
            }
        }
        if (swirlON == true) {
            SpawnPointChance = Random.Range(0, swirlSpawn.Count - 1);
            Instantiate(swirl, swirlSpawn[SpawnPointChance]);
        }
        if (rapidON == true) {
            SpawnPointChance = Random.Range(0, rapidSpawn.Count - 1);
            Instantiate(rapid, rapidSpawn[SpawnPointChance]);
        }
        if (octopusON == true) {
            SpawnPointChance = Random.Range(0, octopusSpawn.Count - 1);
            Instantiate(octopus, octopusSpawn[SpawnPointChance]);
        }
        if (crabON == true) {
            SpawnPointChance = Random.Range(0, crabSpawn.Count - 1);
            Instantiate(crab, crabSpawn[SpawnPointChance]);
        }


    }

    // Update is called once per frame
    void Update() {
        
        if (Vector3.Distance(this.transform.position, new Vector3(0, 0, 0)) > DestroyDistance) 
         {
            Destroy(gameObject);
         }
    }
    void FixedUpdate() {
       
        GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, -SqrSpeed);
    }
   
    }

