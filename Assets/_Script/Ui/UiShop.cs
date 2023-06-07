using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UiShop : MonoBehaviour {

    [SerializeField] private Button btn_Close;
    public GameObject noAdsPanel;

    [Header("Animation Data")]
    [SerializeField] private float flt_StratanimationTime;
    [SerializeField] private float flt_EndAnimationTime;
    [SerializeField] private RectTransform rect_Bg;
    [SerializeField] private RectTransform[] all_rectPanel;

   
   

    

    private void OnEnable() {

        if (DataManager.instance.hasPurchasedNoAds) {

            noAdsPanel.gameObject.SetActive(false);
        }
        StartUiAnimation();
    }

    public void Onclick_OnCloseBtnClick() {

        AudioManager.instance.PlayBtnClickSFX();
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(EndOfUiAnimation).AppendInterval(flt_EndAnimationTime).
            AppendCallback(CloseBtnProcedure);
    }
    public void Onclick_OnBuyBtnClick(int index) {
        AudioManager.instance.PlayBtnClickSFX();
        FindObjectOfType<IAPManager>().BuyConsumable(index);
        //if (index == 0) {
        //    Debug.Log("Buy Noads");
        //    noAdsPanel.gameObject.SetActive(false);
        //}
        //else if (index == 1) {
        //    Debug.Log("Add  100 Coin");
        //    DataManager.instance.SetCoin(100);
        //}
        //else if (index == 2) {
        //    DataManager.instance.SetCoin(500);
        //}
        //else if (index == 3) {
        //    DataManager.instance.SetCoin(2000);
        //}
        //else if (index == 4) {
        //    DataManager.instance.SetCoin(5000);
        //}
    }
    private void StartUiAnimation() {
        Sequence seq = DOTween.Sequence();
        seq.Append(rect_Bg.DOScale(1, flt_StratanimationTime).SetEase(Ease.Linear)).
                 AppendCallback(Cour_AllPanel)
                 
                 
                 .AppendInterval(flt_StratanimationTime * 2.5f)
            .Append(UiManager.instance.CommanScreeen.transform.
            DOLocalMoveY(0, flt_StratanimationTime).
            SetEase(Ease.Linear));
    }

    private void Cour_AllPanel() {
        StartCoroutine(AllPanelScaleUp());
    }

    private IEnumerator AllPanelScaleUp() {

        for (int i = 0; i < all_rectPanel.Length; i++) {
            all_rectPanel[i].DOScale(1, flt_StratanimationTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(flt_StratanimationTime/2);
        }
    }

  
    private void CloseBtnProcedure() {
        this.gameObject.SetActive(false);

        if (UiManager.instance.uiPlayerSelection.gameObject.activeSelf) {
            return;
        }
        if (UiManager.instance.uiSetting.gameObject.activeSelf) {
            return;
        }
        if (UiManager.instance.UiHomeScreen.gameObject.activeSelf) {
            return;
        }
        UiManager.instance.UiHomeScreen.gameObject.SetActive(true);
    }

    private void EndOfUiAnimation() {
        rect_Bg.DOScale(0, flt_EndAnimationTime).SetEase(Ease.Linear);
        for (int i = 0; i < all_rectPanel.Length; i++) {
            all_rectPanel[i].DOScale(0, flt_EndAnimationTime).SetEase(Ease.OutBounce);
        }

        if (UiManager.instance.uiPlayerSelection.gameObject.activeSelf) {
            return;
        }
        if (UiManager.instance.uiSetting.gameObject.activeSelf) {
            return;
        }
        if (UiManager.instance.UiHomeScreen.gameObject.activeSelf) {
            return;
        }
        UiManager.instance.CommanScreeen.transform.DOLocalMoveY(500, flt_EndAnimationTime).
            SetEase(Ease.Linear);
    }
}
