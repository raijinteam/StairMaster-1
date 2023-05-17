using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UICommanScreen : MonoBehaviour
{
    public Button btn_AddCoin;
    [SerializeField] private TextMeshProUGUI txt_Coin;

   
    public void SetCoinValue(int CoinValue) {
        txt_Coin.text = CoinValue.ToString();
    }

    public void OnclickOn_AddBtn() {

        if (UiManager.instance.UiHomeScreen.gameObject.activeSelf) {
            UiManager.instance.UiHomeScreen.Onclick_ShopBtnClick();
        }
        else {
            AudioManager.instance.PlayBtnClickSFX();
            UiManager.instance.uishop.gameObject.SetActive(true);
        }
       
    }
   
}
