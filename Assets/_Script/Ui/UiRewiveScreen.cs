using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiRewiveScreen : MonoBehaviour
{
    [Header("Component")]
  
    [SerializeField] private TextMeshProUGUI txt_Counter;

    [Header("Rewive Data")]
    [SerializeField] private float flt_CurrentTime = 0;
    [SerializeField] private float flt_ReWiveTime;
    [SerializeField] private Vector2 playerPostion;

    //Tag
    private string tag_Enemy = "Enemy";

    private void OnEnable() {
        flt_CurrentTime = flt_ReWiveTime;
        txt_Counter.text = ((int)flt_ReWiveTime).ToString();
      
    }

    private void Update() {
        ReWiveCounter();
    }

    private void ReWiveCounter() {
        flt_CurrentTime -= Time.deltaTime;
        txt_Counter.text = ((int)flt_CurrentTime).ToString();
        if (flt_CurrentTime<0) {
            this.gameObject.SetActive(false);
            UiManager.instance.uiGameOverScreen.gameObject.SetActive(true);
        }
    }
    public void Onclick_ReWiveBtnClick() {

        AudioManager.instance.PlayBtnClickSFX();
        
        FindObjectOfType<AdsManager>().ShowRewardedAd();
    }

    public void RewivePlayer() {

        GameManager.instance.player.transform.position = playerPostion;
        Collider2D[] all_Collider = Physics2D.OverlapCircleAll(playerPostion, 10);

        for (int i = 0; i < all_Collider.Length; i++) {

            if (all_Collider[i].gameObject.CompareTag(tag_Enemy)) {
                Destroy(all_Collider[i].gameObject);
            }
        }

        Playermovement playermovement = GameManager.instance.player.GetComponent
                                                    <Playermovement>();

        playermovement.myBody.gameObject.SetActive(true);
        playermovement.Reset();
        GameManager.instance.isplayerLive = true;
        this.gameObject.SetActive(false);
    }
}
