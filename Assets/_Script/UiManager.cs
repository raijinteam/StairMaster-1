using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [Header("All - Screen")]
    public UiHomeScreen UiHomeScreen;
    public UiGameOverScreen uiGameOverScreen;
    public UiRewiveScreen uiRewiveScreen;
    public UiPlayerSelection uiPlayerSelection;
    public UiGamplayScreen uiGameplay;
    public UiSetting uiSetting;
    public UiShop uishop;
    public UICommanScreen CommanScreeen;

    [SerializeField] private bool isPlayerTakeRewive;

    private void Awake() {
        instance = this;
    }
    private void Start() {
        isPlayerTakeRewive = false;
    }

    private void Update() {

        if (uiGameplay.gameObject.activeSelf) {
            Debug.Log("active");
        }
        else {
            Debug.Log("not active");
        }
    }

    public void SetUiGameOverScreen() {

        GameManager.instance.isplayerLive = false;
            StartCoroutine(delayOnGameOverScrren());
       
       
    }

    private IEnumerator delayOnGameOverScrren() {
        yield return new WaitForSeconds(1);
        if (!isPlayerTakeRewive) {
            UiManager.instance.uiRewiveScreen.gameObject.SetActive(true);
            isPlayerTakeRewive = true;
        }
        else {
            UiManager.instance.uiGameOverScreen.gameObject.SetActive(true);
        }
       
    }

}
