using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
     private float SmallEnemy1 = 4.65f ;
    private float SmallEnemy2 = 9.5f ;
   
    [SerializeField] private float flt_PostionOfX;
    [SerializeField] private int persantageOfSpwnSmallEnemy;


    [SerializeField] private float flt_SpwnRate;
    private float flt_CurrentTime;
    private void Update() {

        if (!GameManager.instance.isplayerLive) {
            return;
        }
        if (flt_SpwnRate>0.4f ) {
            flt_SpwnRate = 3 - GameManager.instance.currentLevelIndex * 0.08f;
        }
        else {
            flt_SpwnRate = 0.4f;
        }
       
        flt_CurrentTime += Time.deltaTime;
        if (flt_CurrentTime> flt_SpwnRate) {
            SpawnEnemy();
            flt_CurrentTime = 0;
        }
       
    }

    private void SpawnEnemy() {

        int i = Random.Range(0, 100);
        if (i< persantageOfSpwnSmallEnemy) {
            InstantiateEnemy(0);
        }
      
       
            
    }
    private void InstantiateEnemy(int i) {
        Vector3 spawnPostion;
      
             spawnPostion = GetSpawnPostion(SmallEnemy1,SmallEnemy2);
        Instantiate(enemy[i], spawnPostion, enemy[i].transform.rotation);




    }

    private Vector3 GetSpawnPostion(float min,float max) {
        Vector3 spawnPostion;
        int index = Random.Range(0, 100);
        if (index < 50) {
            spawnPostion = new Vector3(flt_PostionOfX, min, 0);
        }
        else {
            spawnPostion = new Vector3(flt_PostionOfX, max, 0);
        }
        return spawnPostion;
    }
}
