using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject coin_VFx;
    private float flt_Angle;
    private float flt_Speed;


    private void Start() {

        flt_Speed = 6 + GameManager.instance.currentLevelIndex * 0.02f;
        flt_Angle = GameManager.instance.flt_StepAngle;
    }
    private void Update() {
        if (!GameManager.instance.isplayerLive) {
            return;
        }
        EnemyMotion();
       
    }

    private void EnemyMotion() {
        transform.Translate(new Vector3(-Mathf.Cos(flt_Angle * Mathf.Deg2Rad), -Mathf.Sin(flt_Angle * Mathf.Deg2Rad), 0)
            .normalized * flt_Speed * Time.deltaTime);
    }
    public void PlayCoinvfx() {
          Instantiate(coin_VFx, transform.position, transform.rotation/*, transform.parent*/);
        

    }
}
