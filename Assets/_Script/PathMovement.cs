using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathMovement : MonoBehaviour
{

    public bool isTimeToGap;
   [SerializeField] private bool isTop;
    private bool istakeGap = false;
    private float stepAngle;
    [SerializeField] private Transform[] all_Path;
    private float flt_Offset = 9.2f;
    private float flt_MinRange = 1.5f;
    private float flt_MaxRange = 3f;
    [SerializeField]private float flt_Speed;
    private int persantageOfRoad = 110;
    private float roadSpeed;


    private void Start() {

        roadSpeed = GameManager.instance.flt_RoadSpeed;
        stepAngle = GameManager.instance.flt_StepAngle;
    }
    private void Update() {
        if (!GameManager.instance.isplayerLive) {
            return;
        }
        if (flt_Speed < 8) {
            flt_Speed = 3 + GameManager.instance.currentLevelIndex * roadSpeed;
        }
        else {
            flt_Speed = 8;
        }

        // flt_Speed = 50;
        PathMotion();
    }

    private void PathMotion() {
        for (int i = 0; i < all_Path.Length; i++) {

            all_Path[i].transform.localPosition += new Vector3(-Mathf.Cos(stepAngle * Mathf.Deg2Rad),
                                                                -Mathf.Sin(stepAngle * Mathf.Deg2Rad), 0) *
               flt_Speed * Time.deltaTime;

        

            if (all_Path[i].transform.localPosition.x < -Mathf.Cos(stepAngle * Mathf.Deg2Rad) * 2 * flt_Offset || all_Path[i].transform.localPosition.y
                < -Mathf.Sin(stepAngle * Mathf.Deg2Rad) * 2 * flt_Offset) {


                pathChange(i);
                if (isTop) {
                    all_Path[i].GetComponent<SpawnObstaclesTwo>().SpawnDownCoin();

                }
                else {
                    all_Path[i].GetComponent<SpawnObstaclesTwo>().SpawnTopCoin();
                }

            }

            //if (all_Path[i].transform.position.x <= -13.076f) {
            //    pathChange(i);
            //}

        }
    }

    private void pathChange(int i) {
        int index = Random.Range(0, 100);
        if (index < persantageOfRoad && isTimeToGap && !istakeGap) {

            StairSetup(true, i);
            istakeGap = true;
            float currentRange = Random.Range(flt_MinRange, flt_MaxRange);
            if (i == 0) {
                all_Path[i].transform.localPosition = all_Path[all_Path.Length - 1].transform.localPosition + new Vector3((flt_Offset + currentRange)
                    * Mathf.Cos(stepAngle * Mathf.Deg2Rad),
                (flt_Offset + currentRange) * Mathf.Sin(stepAngle * Mathf.Deg2Rad), 0);
            }
            else {
                all_Path[i].transform.localPosition = all_Path[i - 1].transform.localPosition + new Vector3((flt_Offset + currentRange) * Mathf.Cos(stepAngle * Mathf.Deg2Rad),
               (flt_Offset + currentRange) * Mathf.Sin(stepAngle * Mathf.Deg2Rad), 0);
            }


        }
        else {

            WithoutGap(i);


        }
    }

    private void WithoutGap(int i) {


        StairSetup(false, i);
        bool isEnemy2Spawn = false;
        if (isTimeToGap && istakeGap) {
            istakeGap = false;
            PathManager.instance.SetOtherPath();
            SpwnEnemy(i);
            isEnemy2Spawn = true;
        }
        if (!isEnemy2Spawn) {
           // SpwnEnemy1(i);
        }
        if (i == 0) {
            ////all_Path[i].transform.localPosition = all_Path[all_Path.Length - 1].transform.localPosition + new Vector3(flt_Offset * Mathf.Cos(stepAngle * Mathf.Deg2Rad),
            ////flt_Offset * Mathf.Sin(stepAngle * Mathf.Deg2Rad), 0);

            //all_Path[i].transform.position = all_Path[all_Path.Length - 1].transform.position + new Vector3(6.538f, 6.472f, 0);

            StartCoroutine(WaitAndFixPath(i, all_Path.Length - 1));
        }
        else {
            all_Path[i].transform.localPosition = all_Path[i - 1].transform.localPosition + new Vector3(flt_Offset * Mathf.Cos(stepAngle * Mathf.Deg2Rad),
           flt_Offset * Mathf.Sin(stepAngle * Mathf.Deg2Rad), 0);

            all_Path[i].transform.position = all_Path[i - 1].transform.position + new Vector3(6.538f, 6.472f, 0);

            StartCoroutine(WaitAndFixPath(i, i - 1));
        }
    }

    private IEnumerator WaitAndFixPath(int _myIndex, int _referenceIndex) {

        yield return new WaitForSeconds(0.2f);

        all_Path[_myIndex].transform.localPosition = all_Path[_referenceIndex].transform.localPosition + new Vector3(flt_Offset * Mathf.Cos(stepAngle * Mathf.Deg2Rad),
         flt_Offset * Mathf.Sin(stepAngle * Mathf.Deg2Rad), 0);
    }

    private void SpwnEnemy(int i) {
        Debug.Log("SpawnEnemy");
        if (isTop) {
           
            all_Path[i].GetComponent<SpawnObstaclesTwo>().TopSideEnemySpawn();
        }
        else {
            all_Path[i].GetComponent<SpawnObstaclesTwo>().DownSideEnemySpawn();
        }
    }

    private void StairSetup(bool value , int i) {
        all_Path[i].GetComponent<SpawnObstaclesTwo>().StartStair.gameObject.SetActive(value);
        if (i - 1 < 0) {
            all_Path[all_Path.Length - 1].GetComponent<SpawnObstaclesTwo>().EndStair.SetActive(value);
        }
        else {
            all_Path[i - 1].GetComponent<SpawnObstaclesTwo>().EndStair.gameObject.SetActive(value);
        }
    }
   
}
