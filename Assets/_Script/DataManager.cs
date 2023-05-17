using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    PlayerPrefsKey userKey = new PlayerPrefsKey();
    public bool isMusic;
    public bool isSound;
    public int coin;
    public int bestScore;
    public int PlayerIndex;
    public PlayerProperites[] all_PlayerProperites;
   

    private void Awake() {

        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        }

        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }

        Application.targetFrameRate = 60;
    }

    private void Start() {
        if (PlayerPrefs.HasKey(userKey.key_TotalCoin)) {
            GetDataFromPlayerPrefs();
            Debug.Log("GetData");
        }
        else {
           
            SetDataInPlayerprefs();
            Debug.Log("SetData");
        }

       
       
        if (isMusic) {
            AudioManager.instance.PlayBGM();
        }
        else {
            AudioManager.instance.StopBGM();
        }
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PlayerPrefs.DeleteAll();
        }
    }


    private void SetDataInPlayerprefs() {
        PlayerPrefs.SetInt(userKey.key_TotalCoin, coin);
        PlayerPrefs.SetInt(userKey.key_BestScore, bestScore);
        PlayerPrefs.SetInt(userKey.key_CurrentShipIndex, PlayerIndex);
       
        for (int i = 0; i < all_PlayerProperites.Length; i++) {
            if (all_PlayerProperites[i].GetStatusPlayerUnlocked()) {
                PlayerPrefs.SetInt(userKey.key_AllplayerUnlockedStatus + i, 1);
            }
            else {
                PlayerPrefs.SetInt(userKey.key_AllplayerUnlockedStatus + i, 0);
            }
           
        }
        if (isMusic) {
            PlayerPrefs.SetInt(userKey.key_Music, 1);
        }
        else {
            PlayerPrefs.SetInt(userKey.key_Music, 0);
        }
        if (isSound) {
           
            PlayerPrefs.SetInt(userKey.key_Sound, 1);
        }
        else {
            
            PlayerPrefs.SetInt(userKey.key_Sound, 0);
        }

    }

    private void GetDataFromPlayerPrefs() {

        coin = PlayerPrefs.GetInt(userKey.key_TotalCoin);
        bestScore = PlayerPrefs.GetInt(userKey.key_BestScore);
        PlayerIndex = PlayerPrefs.GetInt(userKey.key_CurrentShipIndex);
        if (PlayerPrefs.GetInt(userKey.key_Music) == 1) {
            isMusic = true;
        }
        else {
            isMusic = false;
        }
        if (PlayerPrefs.GetInt(userKey.key_Sound) == 1) {
            isSound = true;
        }
        else {
            isSound = false;
        }
        for (int i = 0; i < all_PlayerProperites.Length; i++) {

            if (PlayerPrefs.GetInt(userKey.key_AllplayerUnlockedStatus + i) == 0) {
                all_PlayerProperites[i].SetPlayerUnLockedStatus(false);
            }
            else {
                all_PlayerProperites[i].SetPlayerUnLockedStatus(true);
            }
        }
        
    }

    public void SetCoin(int coinValue) {
        coin += coinValue;
        PlayerPrefs.SetInt(userKey.key_TotalCoin, coin);
        UiManager.instance.CommanScreeen.SetCoinValue(coin);
    }
    public void SetBestScore(int CurrentScore) {
        if (CurrentScore>PlayerPrefs.GetInt(userKey.key_BestScore)) {
            PlayerPrefs.SetInt(userKey.key_BestScore, CurrentScore);
        }
    }
    public void SetMusic(bool MusicValue) {
        isMusic = MusicValue;
        if (isMusic) {
            PlayerPrefs.SetInt(userKey.key_Music, 1);
            AudioManager.instance.PlayBGM();
        }
        else {
            PlayerPrefs.SetInt(userKey.key_Music, 0);
            AudioManager.instance.StopBGM();
        }
    }
    public void SetSound(bool SoundValue) {
        isSound = SoundValue;
        if (isSound) {
            PlayerPrefs.GetInt(userKey.key_Sound, 1);
        }
        else {
            PlayerPrefs.GetInt(userKey.key_Sound, 0);
        }
    }
    public void SetPlayerIndex(int Index) {
        PlayerIndex = Index;
        PlayerPrefs.SetInt(userKey.key_CurrentShipIndex, Index);
    }
    public void SetStatusOfPlayer(int PropertyIndex, bool Status) {
        all_PlayerProperites[PropertyIndex].SetPlayerUnLockedStatus(Status);
        PlayerPrefs.SetInt(userKey.key_AllplayerUnlockedStatus + PropertyIndex, 1);
    }

}
