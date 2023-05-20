using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{

  
    [SerializeField] private float flt_SpeedOfForGround;
    [SerializeField] private float flt_SpeedMiddleGround;
    [SerializeField] private float flt_SpeedBackGround;

    [SerializeField] private GameObject[] all_FrontGround;
    [SerializeField] private GameObject[] all_MiddleGround;
    [SerializeField] private GameObject[] all_BackGround;

    [SerializeField] private float flt_OffSetOfForGround;
    [SerializeField] private float flt_OffsetOfMiddleGround;
    [SerializeField] private float flt_OffsetOfBackGround;


    private void Update() {
        if (!GameManager.instance.isplayerLive) {
            return;
        }
        forGroundMotion();
        MiddleGroundMotion();
        CloudMotion();
       
    }

    private void CloudMotion() {
        for (int i = 0; i < all_BackGround.Length; i++) {
            all_BackGround[i].transform.Translate(Vector3.left * flt_SpeedBackGround * Time.deltaTime);

            if (all_BackGround[i].transform.localPosition.x < -flt_OffsetOfBackGround) {

                int target;
                if (i == 0) {
                    target = all_BackGround.Length - 1;
                }
                else {
                    target = i - 1;
                }
                all_BackGround[i].transform.localPosition = all_BackGround[target].transform.localPosition +
                new Vector3(flt_OffsetOfBackGround, all_BackGround[i].transform.localPosition.y,
                all_BackGround[i].transform.localPosition.z);


                StartCoroutine(SetCloud(i, target));


            }

        }
    }

    private IEnumerator SetCloud(int i, int target) {
        yield return new WaitForSeconds(0.1f);
        all_BackGround[i].transform.localPosition = all_BackGround[target].transform.localPosition +
              new Vector3(flt_OffsetOfBackGround, all_BackGround[i].transform.localPosition.y,
              all_BackGround[i].transform.localPosition.z);

    }

    private void MiddleGroundMotion() {
        for (int i = 0; i < all_MiddleGround.Length; i++) {
            all_MiddleGround[i].transform.Translate(Vector3.left * flt_SpeedMiddleGround * Time.deltaTime);

            if (all_MiddleGround[i].transform.localPosition.x < -flt_OffsetOfMiddleGround) {

                int target;
                if (i == 0) {
                    target = all_MiddleGround.Length - 1;
                }
                else {
                    target = i - 1;
                }
                all_MiddleGround[i].transform.localPosition = all_MiddleGround[target].transform.localPosition +
                new Vector3(flt_OffsetOfMiddleGround, all_MiddleGround[i].transform.localPosition.y,
                all_MiddleGround[i].transform.localPosition.z);


                StartCoroutine(SetMiddleGround(i, target));


            }

        }
    }

    private IEnumerator SetMiddleGround(int i, int target) {
        yield return new WaitForSeconds(0.1f);
        all_MiddleGround[i].transform.localPosition = all_MiddleGround[target].transform.localPosition +
                new Vector3(flt_OffsetOfMiddleGround, all_MiddleGround[i].transform.localPosition.y,
                all_MiddleGround[i].transform.localPosition.z);

    }

    private void forGroundMotion() {
        for (int i = 0; i < all_FrontGround.Length; i++) {
            all_FrontGround[i].transform.Translate(Vector3.left * flt_SpeedOfForGround * Time.deltaTime);

            if (all_FrontGround[i].transform.localPosition.x<-flt_OffSetOfForGround) {

                int target;
                if (i==0) {
                    target = all_FrontGround.Length - 1;
                }
                else {
                    target = i - 1;
                }
                all_FrontGround[i].transform.localPosition = all_FrontGround[target].transform.localPosition +
                new Vector3(flt_OffSetOfForGround, all_FrontGround[i].transform.localPosition.y,
                all_FrontGround[i].transform.localPosition.z);

                
                    StartCoroutine(SetForPostion(i, target));
               

            }
               
        }
    }

    private IEnumerator SetForPostion(int i, int target) {
        yield return new WaitForSeconds(0.1f);
        all_FrontGround[i].transform.localPosition = all_FrontGround[target].transform.localPosition +
                  new Vector3(flt_OffSetOfForGround, all_FrontGround[i].transform.localPosition.y,
                  all_FrontGround[i].transform.localPosition.z);

    }
}
