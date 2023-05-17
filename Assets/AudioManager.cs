using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("AudioSource")]
    [SerializeField] private AudioSource audioSource_BGM;
    [SerializeField] private AudioSource audioSource_PlayerDieSFX;
    [SerializeField] private AudioSource audioSource_PlayerJumpSFX;
    [SerializeField] private AudioSource audioSource_PlayerPathChangeSFX;
    [SerializeField] private AudioSource audioSource_CoinCollectSFX;
    [SerializeField] private AudioSource audioSource_ButtonClickSFX;
    [SerializeField]private AudioSource audioSource_Unlocked;

    private void Awake() {

        //// If there is not already an instance of SoundManager, set it to this.
        //if (instance == null) {
        //    instance = this;
        //}
        ////If an instance already exists, destroy whatever this object is to enforce the singleton.
        //else if (instance != this) {
        //    Destroy(gameObject);
        //}

        ////Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        //DontDestroyOnLoad(gameObject);
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
    }

    public void  PlayBGM() {
        audioSource_BGM.Play();
    }
    public void StopBGM() {
        audioSource_BGM.Stop();
    }
    public void PlayDieSFX() {
        if (!DataManager.instance.isSound) {
            return;
        }
        audioSource_PlayerDieSFX.Play();
    }
    public void PlayJumpSFX() {
        if (!DataManager.instance.isSound) {
            return;
        }
        audioSource_PlayerJumpSFX.Play();
    }
    public void PlayPathChangeSFX() {
        if (!DataManager.instance.isSound) {
            return;
        }
        audioSource_PlayerPathChangeSFX.Play();
    }
    public void PlayCoinCollectSFX() {
        if (!DataManager.instance.isSound) {
            return;
        }
        audioSource_CoinCollectSFX.Play();
    }

    public void PlayBtnClickSFX() {
        if (!DataManager.instance.isSound) {
            return;
        }
        audioSource_ButtonClickSFX.Play();
    }

    public void PlayUnlockedSFX() {
        if (!DataManager.instance.isSound) {
            return;
        }
        audioSource_Unlocked.Play();
    }
}
