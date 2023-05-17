using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    [SerializeField] private GameObject[]  all_FrontGround;
    [SerializeField] private GameObject[] all_MiddleGround;
    [SerializeField] private GameObject[] all_BackGround;
    [SerializeField] private float flt_SpeedOfForntGround;
    [SerializeField] private float flt_SpeedMiddleGround;
    [SerializeField] private float flt_SpeedBackGround;
    [SerializeField] private float flt_OffSetOfForGround;
    [SerializeField] private float flt_OffsetOfMiddleGround;
    [SerializeField] private float flt_OffsetOfBackGround;


    private void Update() {
        if (!GameManager.instance.isplayerLive) {
            return;
        }
        ForGroundMotion();
        MiddleGroundMotion();
        BackGroundMotion();
    }

    private void ForGroundMotion() {
        for (int i = 0; i < all_FrontGround.Length; i++) {

            all_FrontGround[i].transform.Translate(Vector3.left * flt_SpeedOfForntGround * Time.deltaTime);
            if (all_FrontGround[i].transform.position.x<-flt_OffSetOfForGround) {
                all_FrontGround[i].transform.position = new Vector3(flt_OffSetOfForGround * 2, all_FrontGround[i].transform
                    .position.y, all_FrontGround[i].transform.position.z);
            }
        }
    }
    private void BackGroundMotion() {
        for (int i = 0; i < all_BackGround.Length; i++) {

            all_BackGround[i].transform.Translate(Vector3.left * flt_SpeedBackGround * Time.deltaTime);
            if (all_BackGround[i].transform.position.x < -flt_OffsetOfBackGround) {
                all_BackGround[i].transform.position = new Vector3(flt_OffsetOfBackGround * 2, all_BackGround[i].transform
                    .position.y, all_BackGround[i].transform.position.z);
            }
        }
    }

    private void MiddleGroundMotion() {
        for (int i = 0; i < all_MiddleGround.Length; i++) {

            all_MiddleGround[i].transform.Translate(Vector3.left * flt_SpeedMiddleGround * Time.deltaTime);
            if (all_MiddleGround[i].transform.position.x < -flt_OffsetOfMiddleGround) {
                all_MiddleGround[i].transform.position = new Vector3(flt_OffsetOfMiddleGround * 2, all_MiddleGround[i].transform
                    .position.y, all_MiddleGround[i].transform.position.z);
            }
        }
    }

  
}
