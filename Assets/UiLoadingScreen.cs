using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiLoadingScreen : MonoBehaviour
{
    [SerializeField] private float flt_LoadingTime = 3;
    [SerializeField] private Slider slider_Loading;
    private float flt_CurrentTime = 0;

    private void Update() {
        flt_CurrentTime += Time.deltaTime / flt_LoadingTime;
        slider_Loading.value = flt_CurrentTime;
        if (flt_CurrentTime>1) {
            SceneManager.LoadScene(1);
        }
    }

}
