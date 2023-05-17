using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UiPlayerSelection : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button btn_Left;
    [SerializeField] private Button btn_Right;
    [SerializeField] private Button btn_Purchase;
    [SerializeField] private Button btn_Selection;
    [SerializeField] private Button btn_Close;

    [Header("SetUp - Data")]
    [SerializeField] private ParticleSystem particle_Unlocked;
    [SerializeField] private GameObject[] all_Player;
    [SerializeField] private GameObject[] all_Lock;
    [SerializeField] private RectTransform obj_Selcted;
    [SerializeField] private RectTransform obj_Buy;
    [SerializeField] private TextMeshProUGUI txt_PriceOfPlayer;
    private int curentIndex;

    [Header("AnimatioData")]
    [SerializeField] private RectTransform rect_BtnClose;
    [SerializeField] private RectTransform rect_BtnLeft;
    [SerializeField] private RectTransform rect_BtnRight;
    [SerializeField] private float flt_StartAnimationTime;
    [SerializeField] private float flt_EndAnimationData;


   
    private void OnEnable() {

        curentIndex = DataManager.instance.PlayerIndex;
        SetPlayerSelectionUi(curentIndex);
        StarUiAnimation();
    }

    public void OnclikOn_BtnLeftClick() {

        AudioManager.instance.PlayBtnClickSFX();
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(SetDeactvateBtn).AppendCallback(BeforeSetBtnAnimation).
            AppendInterval(flt_EndAnimationData).AppendCallback(LeftBtnClickProcedure)
            .AppendCallback(AfterSetBtnAnimation).AppendInterval(flt_StartAnimationTime).
            AppendCallback(SetActiveBtn);

    }

    public void OnclickOn_RightBrnClick() {

        AudioManager.instance.PlayBtnClickSFX();
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(SetDeactvateBtn).AppendCallback(BeforeSetBtnAnimation).
            AppendInterval(flt_EndAnimationData).AppendCallback(RightBtnProcedure)
            .AppendCallback(AfterSetBtnAnimation).AppendInterval(flt_StartAnimationTime).
            AppendCallback(SetActiveBtn);

    }

    public void Onclick_OnPurchaseBtnClick() {

        if (DataManager.instance.coin < DataManager.instance.all_PlayerProperites[curentIndex]
            .GetPriceOfPlayer()) {
            return;
        }

        particle_Unlocked.Play();
        AudioManager.instance.PlayUnlockedSFX();
        DataManager.instance.SetCoin(-DataManager.instance.all_PlayerProperites[curentIndex]
            .GetPriceOfPlayer());
        DataManager.instance.SetStatusOfPlayer(curentIndex, true);
        AudioManager.instance.PlayBtnClickSFX();
        SetPlayerSelectionUi(curentIndex);
    }

    public void Onclick_OnBtnSelectionClick() {

        AudioManager.instance.PlayBtnClickSFX();
        DataManager.instance.SetPlayerIndex(curentIndex);
        SetPlayerSelectionUi(curentIndex);
    }

    public void OnClick_OnClosebtnClick() {

        AudioManager.instance.PlayBtnClickSFX();
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(EndOfUiAnimation).AppendInterval(flt_EndAnimationData).
            AppendCallback(CloseBtnProcedure);

    }


    private void StarUiAnimation() {
      
        Sequence seq = DOTween.Sequence();
        SetDeactvateBtn();
        seq.AppendCallback(All_ButtonSetPostion).AppendInterval(flt_StartAnimationTime).
            AppendCallback(ScaleupPlayer).AppendInterval(flt_StartAnimationTime).
            Append(UiManager.instance.CommanScreeen.transform.DOLocalMoveY(0,
            flt_StartAnimationTime).SetEase(Ease.Linear)).
            AppendCallback(SetActiveBtn);
    }

    private void SetActiveBtn() {
        btn_Left.interactable = true;
        btn_Right.interactable = true;
        btn_Purchase.interactable = true;
        btn_Selection.interactable = true;
        btn_Close.interactable = true;
    }
    private void SetDeactvateBtn() {
        btn_Left.interactable = false;
        btn_Right.interactable = false;
        btn_Purchase.interactable = false;
        btn_Selection.interactable = false;
        btn_Close.interactable = false;
    }

    private void All_ButtonSetPostion() {
        rect_BtnClose.DOAnchorPosY(0, flt_StartAnimationTime).SetEase(Ease.Linear);
        rect_BtnLeft.DOAnchorPosX(0, flt_StartAnimationTime).SetEase(Ease.Linear);
        rect_BtnRight.DOAnchorPosX(0, flt_StartAnimationTime).SetEase(Ease.Linear);
    }

    private void ScaleupPlayer() {
        all_Player[curentIndex].transform.DOScale(1, flt_StartAnimationTime).SetEase(Ease.Linear);
    }

   

    private void SetPlayerSelectionUi(int GivenIndex) {

        for (int i = 0; i < all_Player.Length; i++) {
            all_Player[i].gameObject.SetActive(false);
            all_Lock[i].gameObject.SetActive(false);
            
        }

        if (DataManager.instance.all_PlayerProperites[GivenIndex].GetStatusPlayerUnlocked()) {

            // If PlayerUnlocked

            all_Lock[GivenIndex].gameObject.SetActive(false);
            all_Player[GivenIndex].gameObject.SetActive(true);
            obj_Buy.gameObject.SetActive(false);
           
            if (GivenIndex == DataManager.instance.PlayerIndex) {
                obj_Selcted.gameObject.SetActive(false);
            }
            else {
                obj_Selcted.gameObject.SetActive(true);
            }
        }
        else {
            // if Playeris Not Locked

            all_Lock[GivenIndex].gameObject.SetActive(true);
            all_Player[GivenIndex].gameObject.SetActive(true);
            obj_Buy.gameObject.SetActive(true);
            obj_Selcted.gameObject.SetActive(false);
            txt_PriceOfPlayer.text = DataManager.instance.all_PlayerProperites[GivenIndex].
                                                                    GetPriceOfPlayer().ToString();
           
            
        }
    }

   

    

    private void RightBtnProcedure() {
        curentIndex++;
        if (curentIndex == all_Player.Length) {
            curentIndex = 0;
        }
        SetPlayerSelectionUi(curentIndex);
    }

    

    private void LeftBtnClickProcedure() {
        curentIndex--;
        if (curentIndex < 0) {
            curentIndex = all_Player.Length - 1;
        }
        SetPlayerSelectionUi(curentIndex);
    }

    private void BeforeSetBtnAnimation() {
        
        all_Player[curentIndex].transform.DOScale(0, flt_EndAnimationData).SetEase(Ease.Linear);
        obj_Selcted.DOAnchorPosX(500, flt_EndAnimationData).SetEase(Ease.Linear);
        obj_Buy.DOAnchorPosX(500, flt_EndAnimationData).SetEase(Ease.Linear);
    }
    private void AfterSetBtnAnimation() {
        
        all_Player[curentIndex].transform.DOScale(1, flt_StartAnimationTime).SetEase(Ease.Linear);
        obj_Selcted.DOAnchorPosX(0, flt_EndAnimationData).SetEase(Ease.Linear);
        obj_Buy.DOAnchorPosX(0, flt_EndAnimationData).SetEase(Ease.Linear);
    }
   

  
   

    private void EndOfUiAnimation() {

        rect_BtnClose.DOAnchorPosY(500, flt_EndAnimationData);
        rect_BtnLeft.DOAnchorPosX(-500, flt_EndAnimationData);
        rect_BtnRight.DOAnchorPosX(500, flt_EndAnimationData);
        obj_Buy.DOAnchorPosX(500, flt_EndAnimationData);
        obj_Selcted.DOAnchorPosX(500, flt_EndAnimationData);
        for (int i = 0; i < all_Player.Length; i++) {
            all_Player[i].transform.DOScale(0, flt_EndAnimationData);
        }
        UiManager.instance.CommanScreeen.transform.DOLocalMoveY(500,
            flt_EndAnimationData).SetEase(Ease.Linear);
    }

    private void CloseBtnProcedure() {
        this.gameObject.SetActive(false);
        UiManager.instance.UiHomeScreen.gameObject.SetActive(true);
    }
}
