using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstaclesTwo : MonoBehaviour
{
    public GameObject StartStair;
    public GameObject EndStair;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject[] obstrackle2;
    [SerializeField] private Transform[] all_TopPostion;
    [SerializeField] private Transform[] all_DownPostion;
    [SerializeField] private Transform[] all_CoinTopPostion;
    [SerializeField] private Transform[] all_CoinDownPostion;
    private float flt_PersantageOfSpawnCoin = 3;
  
    
    public void TopSideEnemySpawn() {


        int current = Random.Range(0, all_TopPostion.Length);
      
        Vector3 spawnPostion = new Vector3(all_TopPostion[current].transform.position.x, 
            all_TopPostion[current].transform.position.y, 0);
       
       GameObject Obst =  Instantiate(obstrackle2[Random.Range(0, obstrackle2.Length)], spawnPostion,
           Quaternion.identity, all_TopPostion[current]);
    
    }
    public void DownSideEnemySpawn() {


        int current = Random.Range(0, all_DownPostion.Length);
        Vector3 spawnPostion = new Vector3(all_DownPostion[current].transform.position.x, 
            all_DownPostion[current].transform.position.y, 0);
        GameObject Obst = Instantiate(obstrackle2[Random.Range(0, obstrackle2.Length)], 
            spawnPostion, Quaternion.identity, all_DownPostion[current]);
   
    }
    public void SpawnTopCoin() {
        //for (int i = 0; i < all_CoinTopPostion.Length; i++) {

        //    int index = Random.Range(0, 100);
        //    if (index< flt_PersantageOfSpawnCoin) {
        //      GameObject current = Instantiate(coin, all_CoinTopPostion[i].position, Quaternion.identity,all_CoinTopPostion[i]);
        //        current.transform.localPosition = Vector3.zero;
        //        current.transform.localEulerAngles = Vector3.zero;
        //    }
        //}
    }
    public void SpawnDownCoin() {
        //for (int i = 0; i < all_CoinDownPostion.Length; i++) {

        //    int index = Random.Range(0, 100);
        //    if (index < flt_PersantageOfSpawnCoin) {
        //     GameObject current = Instantiate(coin, all_CoinDownPostion[i].position,Quaternion.identity, all_CoinDownPostion[i]);
        //        current.transform.localPosition = Vector3.zero;
        //        current.transform.localEulerAngles = Vector3.zero;
        //    }
        //}
    }

}
