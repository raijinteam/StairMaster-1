using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UiGameOverScreen : MonoBehaviour
{
    [SerializeField] private Button btn_Restart;

    private void Awake() {
        btn_Restart.onClick.AddListener(OnclickOn_RestartBtnClick);
    }

    private void OnclickOn_RestartBtnClick() {
        SceneManager.LoadScene(0);
    }
}
