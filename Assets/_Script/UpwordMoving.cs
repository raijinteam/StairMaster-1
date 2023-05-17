using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpwordMoving : MonoBehaviour
{
    [SerializeField] private Sprite[] all_Sprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform body;
    private float flt_MinHeight = 0;
    private float flt_MaxHeight = 5.74f;
    public float flt_MoveSpeed;
    private float flt_MinSpeed = 3.5f;
    private float flt_MaxSpeed = 7f;


    private void Start() {

        flt_MoveSpeed = Random.Range(flt_MinSpeed, flt_MaxSpeed);

        spriteRenderer.sprite = all_Sprite[Random.Range(0, all_Sprite.Length)];
        Sequence seq = DOTween.Sequence();
       
        seq.Append(transform.DOLocalMoveY(flt_MaxHeight, flt_MoveSpeed).SetEase(Ease.Linear)).
            Append(transform.DOLocalMoveY(flt_MinHeight, flt_MoveSpeed).SetEase(Ease.Linear)).
            SetLoops(-1, LoopType.Yoyo);

    }
    private void Update() {

        body.transform.Rotate(0, 0, 1.5f);
    }

}
