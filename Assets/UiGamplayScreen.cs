using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UiGamplayScreen : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private TextMeshProUGUI txt_Score;
    [SerializeField] private RectTransform rect_ScorePanel;
    [SerializeField] private float flt_StartAnimation;
    
    private void OnEnable() {

        txt_Score.text = GameManager.instance.score.ToString();
        UiManager.instance.CommanScreeen.btn_AddCoin.gameObject.SetActive(false);
        rect_ScorePanel.DOAnchorPosY(0, flt_StartAnimation);
        UiManager.instance.CommanScreeen.transform.DOLocalMoveY(0, flt_StartAnimation);
    }

    public void SetScore(int ScoreValue) {
        txt_Score.text = ScoreValue.ToString();
    }

}
