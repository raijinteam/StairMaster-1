using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiSetting : MonoBehaviour
{

    [SerializeField] private GameObject panel_MusicOn;
    [SerializeField] private GameObject panel_MusicOff;
    [SerializeField] private GameObject panel_SoundOn;
    [SerializeField] private GameObject panel_SoundOff;

    [Header("Animation data")]
    [SerializeField] private float flt_StartAnimationTime;
    [SerializeField] private float flt_EndAnimationTime;
    [SerializeField] private RectTransform[] all_Rect_Btn;
    [SerializeField] private RectTransform rect_BG;
    [SerializeField] private RectTransform rect_Rate;


    private void OnEnable() {
        SetGameScreenOn();
        StartUiAnimation();
    }

    public void OnclickOn_CloseBtnClick() {

        AudioManager.instance.PlayBtnClickSFX();
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(EndUiAnimation).AppendInterval(flt_EndAnimationTime).
            
            AppendCallback(CloseBtnProcedure);
      
    }

   
    public void OnclickOn_SoundBtnClick() {
        AudioManager.instance.PlayBtnClickSFX();
        if (DataManager.instance.isSound) {
           
            DataManager.instance.SetSound(false);
        }
        else {
           
            DataManager.instance.SetSound(true);
        }
        SetGameScreenOn();
    }

    public void OnclickOn_MusicBtnClick() {
        AudioManager.instance.PlayBtnClickSFX();
        if (DataManager.instance.isMusic) {
           
            DataManager.instance.SetMusic(false);
        }
        else {
            DataManager.instance.SetMusic(true);
        }
        SetGameScreenOn();
    }


    private void CloseBtnProcedure() {

        this.gameObject.SetActive(false);
        UiManager.instance.UiHomeScreen.gameObject.SetActive(true);
    }

    private void EndUiAnimation() {
        rect_BG.DOScale(0, flt_EndAnimationTime).SetEase(Ease.Linear);
        rect_Rate.DOScale(0, flt_EndAnimationTime).SetEase(Ease.Linear);
        for (int i = 0; i < all_Rect_Btn.Length; i++) {
            if (i % 2 == 0) {
                all_Rect_Btn[i].DOAnchorPosX(500, flt_EndAnimationTime).SetEase(Ease.Linear);
            }
            else {
                all_Rect_Btn[i].DOAnchorPosX(-500, flt_EndAnimationTime).SetEase(Ease.Linear);
            }
        }
        UiManager.instance.CommanScreeen.transform.DOLocalMoveY(500, flt_EndAnimationTime).
            SetEase(Ease.Linear);
    }

    private void StartUiAnimation() {
        Sequence seq = DOTween.Sequence();
        seq.Append(rect_BG.DOScale(1, flt_StartAnimationTime).SetEase(Ease.Linear)).
            AppendCallback(Cour_AllPanel).AppendInterval(flt_StartAnimationTime * 1.5f).
            Append(rect_Rate.DOScale(1, flt_StartAnimationTime).SetEase(Ease.Linear)).
            Append(UiManager.instance.CommanScreeen.transform.DOLocalMoveY(0, flt_StartAnimationTime).
            SetEase(Ease.Linear));
    }

    private void Cour_AllPanel() {
        StartCoroutine(setSoundAndMusicPanel());
    }

    private IEnumerator setSoundAndMusicPanel() {
        for (int i = 0; i < all_Rect_Btn.Length; i++) {
            all_Rect_Btn[i].DOAnchorPosX(0, flt_StartAnimationTime).SetEase(Ease.Linear);
            yield return new WaitForSeconds(flt_StartAnimationTime / 2);
        }
    }

    private void SetGameScreenOn() {
        if (DataManager.instance.isMusic) {
            panel_MusicOn.gameObject.SetActive(true);
            panel_MusicOff.gameObject.SetActive(false);
        }
        else {
            panel_MusicOff.gameObject.SetActive(true);
            panel_MusicOn.gameObject.SetActive(false);
        }

        if (DataManager.instance.isSound) {
            panel_SoundOn.gameObject.SetActive(true);
            panel_SoundOff.gameObject.SetActive(false);
        }
        else {
            panel_SoundOff.gameObject.SetActive(true);
            panel_SoundOn.gameObject.SetActive(false);
        }
    }
}
