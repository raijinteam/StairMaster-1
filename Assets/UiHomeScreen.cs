using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiHomeScreen : MonoBehaviour
{
    [SerializeField] private Button btn_Play;
    private void Awake() {
        btn_Play.onClick.AddListener(Onclick_PlayBtnClick); 
    }

    private void Onclick_PlayBtnClick() {
        GameManager.instance.StartGame();
        this.gameObject.SetActive(false);
    }
}
