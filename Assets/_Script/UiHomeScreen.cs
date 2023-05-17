using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class UiHomeScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_BestScorePanel;
    [Header("Animation")]
    [SerializeField] private RectTransform rect_PanelScore;
    [SerializeField] private Button btn_Play;
    [SerializeField] private float flt_StartAnimationTime;
    [SerializeField] private float flt_EndAnimationTime;
    [SerializeField] private Button[] all_Button;



   
    private void OnEnable() {

        
        txt_BestScorePanel.text = DataManager.instance.bestScore.ToString();
        StartUiHomeScreenAnimation();
    }

    public void Onclick_PlayBtnClick() {
        AudioManager.instance.PlayBtnClickSFX();
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(EndUiHomeScreenAnimation).AppendInterval(flt_EndAnimationTime).
            AppendCallback(PlayBtnProcedure);

    }
    public void OnClick_LeaderBoardButnClick() {
        AudioManager.instance.PlayBtnClickSFX();
        // LeaderBtnClick
    }
    public void OnClick_PlayerSelectionBtnClick() {

        AudioManager.instance.PlayBtnClickSFX();
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(EndUiHomeScreenAnimation).AppendInterval(flt_EndAnimationTime).
            AppendCallback(PlayerSelectionBtnProcedure);

    }

    public void OnClick_SettingBtnClick() {
        AudioManager.instance.PlayBtnClickSFX();
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(EndUiHomeScreenAnimation).AppendInterval(flt_EndAnimationTime).
            AppendCallback(settingBtnProcedure);

    }
    public void Onclick_ShopBtnClick() {
        AudioManager.instance.PlayBtnClickSFX();
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(EndUiHomeScreenAnimation).AppendInterval(flt_EndAnimationTime).
            AppendCallback(ShopBtnProcedure);

    }


    private void StartUiHomeScreenAnimation() {

        for (int i = 0; i < all_Button.Length; i++) {
            all_Button[i].interactable = false;
        }
        Sequence seq = DOTween.Sequence();
        seq.Append(btn_Play.transform.DOScale(1, flt_StartAnimationTime).SetEase(Ease.Linear)).
            AppendCallback(Cour_AllBtn).AppendInterval(flt_StartAnimationTime * 2.5f).
            AppendCallback(ScoreAndGemsPanelAnimation).AppendInterval(flt_StartAnimationTime)
         .AppendCallback(All_ButtonInterct);

    }

    private void ScoreAndGemsPanelAnimation() {
        UiManager.instance.CommanScreeen.transform.DOLocalMoveY(0, flt_StartAnimationTime)
         .SetEase(Ease.Linear);
        rect_PanelScore.DOAnchorPosY(0, flt_StartAnimationTime).SetEase(Ease.Linear);

    }

    private void Cour_AllBtn() {
        StartCoroutine(AllBtnCourtine());
    }

    private IEnumerator AllBtnCourtine() {
        for (int i = 1; i < all_Button.Length; i++) {
            all_Button[i].transform.DOLocalMoveY(0, flt_StartAnimationTime).SetEase(Ease.Linear);
            yield return new WaitForSeconds(flt_StartAnimationTime / 2);
        }
       
    }
    private void All_ButtonInterct() {
        for (int i = 0; i < all_Button.Length; i++) {
            all_Button[i].interactable = true;
        }
    }

   

    private void ShopBtnProcedure() {
        this.gameObject.SetActive(false);
        UiManager.instance.uishop.gameObject.SetActive(true);
    }

    
    private void settingBtnProcedure() {
        this.gameObject.SetActive(false);
        UiManager.instance.uiSetting.gameObject.SetActive(true);
    }

   
    private void PlayerSelectionBtnProcedure() {
        this.gameObject.SetActive(false);
        UiManager.instance.uiPlayerSelection.gameObject.SetActive(true);
    }

    

 

    private void PlayBtnProcedure() {
        GameManager.instance.SpawnProcedure();
        this.gameObject.SetActive(false);
        UiManager.instance.uiGameplay.gameObject.SetActive(true);
    }

    private void EndUiHomeScreenAnimation() {

        btn_Play.transform.DOScale(0, flt_EndAnimationTime).SetEase(Ease.Linear);
        for (int i = 1; i < all_Button.Length; i++) {
            all_Button[i].transform.DOLocalMoveY(-500, flt_EndAnimationTime).SetEase(Ease.Linear);
        }
        UiManager.instance.CommanScreeen.transform.DOLocalMoveY(500, flt_EndAnimationTime).
            SetEase(Ease.Linear);
        rect_PanelScore.DOAnchorPosY(500, flt_EndAnimationTime).SetEase(Ease.Linear);
    }
}
