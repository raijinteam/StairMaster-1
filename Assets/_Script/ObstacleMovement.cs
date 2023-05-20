using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleMovement : MonoBehaviour {
    [SerializeField] private Sprite[] all_Sprite;
    [SerializeField] private float flt_Speed;
    [SerializeField] private float flt_Angle;
    [SerializeField] private Transform body;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float flt_RotationSpeed;


    public void SetRotationSpeed(bool IsTop) {
        if (IsTop) {
            flt_RotationSpeed = -flt_RotationSpeed;
        }
    }
    private void Start() {

        //spriteRenderer.sprite = all_Sprite[Random.Range(0, all_Sprite.Length)];
        spriteRenderer.sprite = all_Sprite[4];
        flt_Speed = 6 + GameManager.instance.currentLevelIndex*0.02f;
        flt_Angle = GameManager.instance.flt_StepAngle;
    }
    private void Update() {
        if (!GameManager.instance.isplayerLive) {
            return;
        }
        EnemyMotion();
        body.transform.Rotate(0, 0, flt_RotationSpeed*Time.deltaTime);
    }

    private void EnemyMotion() {
        transform.Translate(new Vector3(-Mathf.Cos(flt_Angle * Mathf.Deg2Rad), -Mathf.Sin(flt_Angle * Mathf.Deg2Rad), 0)
            .normalized * flt_Speed * Time.deltaTime);
    }
}

   