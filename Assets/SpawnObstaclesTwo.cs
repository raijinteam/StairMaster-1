using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstaclesTwo : MonoBehaviour
{
    [SerializeField] private GameObject[] obstrackle2;
    [SerializeField] private Transform[] all_Postion;
  
    
    public void TopSideEnemySpawn() {


        int current = Random.Range(0, all_Postion.Length);
      
        Vector3 spawnPostion = new Vector3(all_Postion[current].transform.position.x, all_Postion[current].transform.position.y, 0);
       
       GameObject Obst =  Instantiate(obstrackle2[Random.Range(0, obstrackle2.Length)], spawnPostion,transform.rotation, transform);

        Obst.transform.localPosition = new Vector3(Obst.transform.localPosition.x, Obst.transform.localPosition.x - 0.3f, 0);
        Obst.transform.localScale = new Vector3(1, -1, 1);
        Obst.transform.rotation = Quaternion.Euler(new Vector3(0,0,45));

    }
    public void DownSideEnemySpawn() {


        int current = Random.Range(0, all_Postion.Length);
        Vector3 spawnPostion = new Vector3(all_Postion[current].transform.position.x, all_Postion[current].transform.position.y, 0);
        GameObject Obst = Instantiate(obstrackle2[Random.Range(0, obstrackle2.Length)], spawnPostion, transform.rotation, transform);
        Obst.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 45));

    }
    
}
