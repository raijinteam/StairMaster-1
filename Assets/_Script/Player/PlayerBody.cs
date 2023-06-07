using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour {

    public Animator animator;
    public Transform target;
    [SerializeField] private GameObject body;
    [SerializeField] private float flt_JumpRotatineTime;

    //private void Start() {
    //    animator.enabled = true;
    //}

    private void Update() {

        transform.position = target.position;


        if (transform.position.y < 0) {
            body.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 20));

        }
        else {
            body.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -40));

        }

    }

    public void RotateBody(Quaternion _targetRotation, bool isTop) {

        StopAllCoroutines();
        StartCoroutine(MotionAnimation(isTop));
    }
    public void JumpRotation(bool jumpTop) {

        StopAllCoroutines();

        if (jumpTop) {
            StartCoroutine(JumptimePlayerRotate(true));
        }
        else {
            StartCoroutine(JumptimePlayerRotate(false));
        }

    }

    private IEnumerator JumptimePlayerRotate(bool isTop) {

        float flt_CurrentTime = 0;
        Vector3 StartRotation = transform.localEulerAngles;
        Vector3 _targetRotation;

        if (isTop) {
            _targetRotation = new Vector3(0, 0, transform.localEulerAngles.z + 180);
        }
        else {
            _targetRotation = new Vector3(0, 0, transform.localEulerAngles.z - 180);
        }
           
       


        float motionTime = flt_JumpRotatineTime / 2;



        while (flt_CurrentTime < 1) {


            flt_CurrentTime += Time.deltaTime / motionTime;
            transform.localEulerAngles = Vector3.Lerp(StartRotation, _targetRotation, flt_CurrentTime);

            yield return null;
        }
        flt_CurrentTime = 0;

        StartRotation = transform.localEulerAngles;

        if (isTop) {
            _targetRotation = new Vector3(0, 0, transform.localEulerAngles.z + 180);
        }
        else {
            _targetRotation = new Vector3(0, 0, transform.localEulerAngles.z - 180);
        }

        while (flt_CurrentTime < 1) {


            flt_CurrentTime += Time.deltaTime / motionTime;

            transform.localEulerAngles = Vector3.Lerp(StartRotation, _targetRotation, flt_CurrentTime);

            yield return null;
        }
        if (isTop) {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z - 360);
        }
        else {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + 360);
        }
       
      

    }

    private IEnumerator MotionAnimation(bool _isGoingTop) {
        float flt_CurrentTime = 0;
        //Quaternion StartRotation = transform.rotation;
        //Quaternion _targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 180);

        Vector3 startRotation = transform.localEulerAngles;
        Vector3 targetRotation = Vector3.zero;

        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y,
          transform.localScale.z);
        if (_isGoingTop) {
            targetRotation = new Vector3(0, 0, 180f);
            
        }
        else {
            targetRotation = new Vector3(0, 0, 0f);
         
        }


        float motionTime = 0.25f;


        while (flt_CurrentTime < 1f) {

            flt_CurrentTime += Time.deltaTime / motionTime;
            transform.localEulerAngles = Vector3.Lerp(startRotation, targetRotation, flt_CurrentTime);


            yield return null;
        }


    }
}
