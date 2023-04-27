using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
   
    public static GameManager instance;
    public bool isplayerLive;
    public float flt_RoadSpeed;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI txt_ScoreTxt;
    [SerializeField] private int score;
    [SerializeField] private float scoreIncresedTime;
    [SerializeField] private float ThisWaveIncresedScore;
    [SerializeField] private Camera camera;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float flt_AnimationTime;
    public int currentLevelIndex;
   
    private float flt_CurrentTime;
    private float flt_EveryLevelChangeTime = 5;
    private float flt_ThisTimeLevelChange = 0;
    public float flt_StepAngle = 36.5f;
    private void Awake() {
        instance = this;
    }
    private void Start() {
        UiManager.instance.UiHomeScreen.gameObject.SetActive(true);
    }

    public  void StartGame() {
        currentLevelIndex = 1;
        flt_CurrentTime = 0;
        flt_ThisTimeLevelChange = flt_EveryLevelChangeTime;
        Instantiate(player, player.transform.position, player.transform.rotation);
        CameraVFx();
        isplayerLive = true;
    }

    private void CameraVFx() {
        camera.backgroundColor = startColor;
        camera.DOColor(endColor, flt_AnimationTime).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
    }

    private void Update() {
        if (isplayerLive) {
            LevelHandling();
        }
      
    }

    private void LevelHandling() {
        flt_CurrentTime += Time.deltaTime;
        txt_ScoreTxt.text = score + " M";
        if (flt_CurrentTime>flt_ThisTimeLevelChange) {
           
                currentLevelIndex++;
                flt_ThisTimeLevelChange += flt_EveryLevelChangeTime;
       
        }
        if (flt_CurrentTime>ThisWaveIncresedScore) {
            score++;
           
            if (scoreIncresedTime >= 0.5f) {
                scoreIncresedTime += - 0.001f;     // findtime to genrate MaxSpeed then calculate velocity  for our distance;
               
            }

            ThisWaveIncresedScore += scoreIncresedTime;
        }
    }
    
}
