using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using DG.Tweening;

public class UiGameOverScreen : MonoBehaviour
{
    [Header("GameOverData")]
    [SerializeField] private TextMeshProUGUI txt_Score;
    [SerializeField] private TextMeshProUGUI txt_Best;
    [SerializeField] private TextMeshProUGUI txt_Coin;
    [SerializeField] private Button btn_Restart;

    [Header("Animation Data")]
    [SerializeField] private GameObject obj_BG;
    [SerializeField] private GameObject header;
    [SerializeField] private GameObject[] all_ScoreProperites;
    [SerializeField] private float flt_StartAnimationTime;
    [SerializeField] private float flt_EndAnimation;

   

   
    private void OnEnable() {
        FindObjectOfType<AdsManager>().ShowInterstitialAd();
        txt_Score.text = GameManager.instance.score.ToString();
        txt_Coin.text = GameManager.instance.GameCollectedCoin.ToString();
        txt_Best.text = DataManager.instance.bestScore.ToString();
        StartUiAnimation();
    }

    public void OnclickOn_RestartBtnClick() {
        AudioManager.instance.PlayBtnClickSFX();
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(endOfUiAnimation).AppendInterval(flt_EndAnimation).AppendCallback(LoadScene);
    }


    private void StartUiAnimation() {
        Sequence seq = DOTween.Sequence();
        seq.Append(obj_BG.transform.DOScale(1, flt_StartAnimationTime).SetEase(Ease.Linear)).
            Append(header.transform.DOScale(1, flt_StartAnimationTime).SetEase(Ease.Linear)).
            AppendCallback(Cour_AllScore).AppendInterval(flt_StartAnimationTime*2)
            .Append(btn_Restart.transform.DOScale(1,flt_StartAnimationTime).SetEase(Ease.Linear));
    }

    private void Cour_AllScore() {
        StartCoroutine(AllScoreStartCour());
    }

    private IEnumerator AllScoreStartCour() {
        for (int i = 0; i < all_ScoreProperites.Length; i++) {
            all_ScoreProperites[i].transform.DOLocalMoveX(0, flt_StartAnimationTime).SetEase(Ease.Linear);
            yield return new WaitForSeconds(flt_StartAnimationTime / 2);
        }
    }

   
    private void endOfUiAnimation() {
        obj_BG.transform.DOScale(0, flt_EndAnimation).SetEase(Ease.Linear);
       header.transform.DOScale(0, flt_EndAnimation).SetEase(Ease.Linear);
        for (int i = 0; i < all_ScoreProperites.Length; i++) {
            if (i%2==0) {
                all_ScoreProperites[i].transform.DOLocalMoveX(-500, flt_EndAnimation).SetEase(Ease.Linear);
            }
            else {
                all_ScoreProperites[i].transform.DOLocalMoveX(500, flt_EndAnimation).SetEase(Ease.Linear);
            }
        }
        btn_Restart.transform.DOScale(0, flt_EndAnimation);
    }
    private void LoadScene() {
        SceneManager.LoadScene(1);
    }

  
}
