using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
     private float MinPostion = 4.26f ;
    private float maxPostion = 9.5f ;
    [SerializeField] private float flt_PostionOfX;
    [SerializeField] private int persantageOfSpwnSmallEnemy;
    [SerializeField] private float flt_SpwnRate;
    private float flt_CurrentTime;

    [Header("Coin")]
    [SerializeField] private GameObject coin;
    private float flt_CurrentCoinTime;
    [SerializeField] private float flt_MaxCoinSpawnTime;
    [SerializeField]private float probabiltyOfSpawnCoin;
    private void Update() {

        if (!GameManager.instance.isplayerLive) {
            return;
        }
        EnemyTimeHandling();
        flt_CurrentCoinTime += Time.deltaTime;
        if (flt_CurrentCoinTime>flt_MaxCoinSpawnTime) {

            flt_CurrentCoinTime = 0;

            SpwnCoin();
           
        }
       
    }

    private void SpwnCoin() {

        int Index = Random.Range(0, 100);
        if (Index <= probabiltyOfSpawnCoin) {
            Vector3 GetSpawnPostion = new Vector3(flt_PostionOfX, Random.Range(MinPostion, maxPostion), 0);
            Instantiate(coin, GetSpawnPostion, transform.rotation);
        }
    }

    private void EnemyTimeHandling() {
        if (flt_SpwnRate > 0.4f) {
            flt_SpwnRate = 3 - GameManager.instance.currentLevelIndex * 0.08f;
        }
        else {
            flt_SpwnRate = 0.4f;
        }

        flt_CurrentTime += Time.deltaTime;
        if (flt_CurrentTime > flt_SpwnRate) {
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
      
             spawnPostion = GetSpawnPostion(MinPostion,maxPostion);
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
