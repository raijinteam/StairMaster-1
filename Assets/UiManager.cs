using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public UiHomeScreen UiHomeScreen;
    public UiGameOverScreen uiGameOverScreen;

    private void Awake() {
        instance = this;
    }

    public void SetUiGameOverScreen() {
        StartCoroutine(delayOnGameOverScrren());
    }

    private IEnumerator delayOnGameOverScrren() {
        yield return new WaitForSeconds(1);
        UiManager.instance.uiGameOverScreen.gameObject.SetActive(true);
    }

}
