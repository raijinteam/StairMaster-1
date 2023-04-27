using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleMovement : MonoBehaviour {
    [SerializeField] private float flt_Speed;
    [SerializeField] private float flt_Angle;
    [SerializeField] private Transform body;
   

    private void Start() {
       
        flt_Speed = 6 + GameManager.instance.currentLevelIndex*0.02f;
        flt_Angle = GameManager.instance.flt_StepAngle;
    }
    private void Update() {
        if (!GameManager.instance.isplayerLive) {
            return;
        }
        EnemyMotion();
        body.transform.Rotate(0, 0, 5);
    }

    private void EnemyMotion() {
        transform.Translate(new Vector3(-Mathf.Cos(flt_Angle * Mathf.Deg2Rad), -Mathf.Sin(flt_Angle * Mathf.Deg2Rad), 0)
            .normalized * flt_Speed * Time.deltaTime);
    }
}

   