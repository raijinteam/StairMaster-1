using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
   
    public static GameManager instance;
    [Header("PlayerData")]
    public GameObject player;
    [SerializeField] private GameObject prefab_Player;
    public bool isplayerLive;


    [Header("GameData")]
    public float flt_RoadSpeed;
    public float flt_StepAngle = 36.5f;

    [Header("ScoreData")]
    public int score;
    [SerializeField] private float scoreIncresedTime;
    [SerializeField] private float ThisWaveIncresedScore;

   
    [Header("LevelData")]
    public int currentLevelIndex;
    private float flt_CurrentTime;

   

    private float flt_EveryLevelChangeTime = 5;
    private float flt_ThisTimeLevelChange = 0;

    [Header("CoinData")]
    public int GameCollectedCoin;
   
    private void Awake() {
        instance = this;
    }

    private void Start() {

        UiManager.instance.UiHomeScreen.gameObject.SetActive(true);
        UiManager.instance.CommanScreeen.gameObject.SetActive(true);
        UiManager.instance.CommanScreeen.SetCoinValue(DataManager.instance.coin);
    }

    private void Update() {
        if (isplayerLive) {
            LevelHandling();
        }

    }
    public void IncresedGameCoin() {
        GameCollectedCoin += 1;
        DataManager.instance.SetCoin(1);


    }


   
    public void SpawnProcedure() {
        GameObject curent = Instantiate(prefab_Player, prefab_Player.transform.position,
                               prefab_Player.transform.rotation);
        player = curent;
        currentLevelIndex = 1;
        flt_CurrentTime = 0;
        flt_ThisTimeLevelChange = flt_EveryLevelChangeTime;
        //curent.GetComponent<Playermovement>().myBody.animator.enabled = true;
        isplayerLive = true;
    }


   

    private void LevelHandling() {
        flt_CurrentTime += Time.deltaTime;
      
      
       
        if (flt_CurrentTime>flt_ThisTimeLevelChange) {
           
                currentLevelIndex++;
                flt_ThisTimeLevelChange += flt_EveryLevelChangeTime;
       
        }
        if (flt_CurrentTime>ThisWaveIncresedScore) {
            score++;
            if (score>DataManager.instance.bestScore) {
                DataManager.instance.SetBestScore(score);
            }
            
            UiManager.instance.uiGameplay.SetScore(score);

            if (scoreIncresedTime >= 0.5f) {
                scoreIncresedTime += - 0.001f;     // findtime to genrate MaxSpeed then calculate velocity  for our distance;
               
            }

            ThisWaveIncresedScore += scoreIncresedTime;
        }
    }

   
    
}
