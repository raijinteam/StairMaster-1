using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public Animator animator;
    public Transform target;
    [SerializeField] private GameObject body;
    [SerializeField] private float flt_JumpRotatineTime;
    private float flt_JumpX;
    private void Update() {

        transform.position = target.position;
        if (transform.position.y<0) {
            body.transform.localRotation  =  Quaternion.Euler(new Vector3(0, 0, 20));
            flt_JumpX = 0;
        }
        else {
            body.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -40));
            flt_JumpX = -180;
        }
        
    }

    public void RotateBody(Quaternion _targetRotation) {

        StopAllCoroutines();
        StartCoroutine(MotionAnimation(_targetRotation));
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
        Quaternion StartRotation = transform.rotation;
        Quaternion _targetRotation;
        if (isTop) {
             _targetRotation = Quaternion.Euler(-180, 0, 180);
        }
        else {
             _targetRotation = Quaternion.Euler(0, 0, 180);
        }
       
       
        float motionTime = flt_JumpRotatineTime/2;

        Debug.Log("pos 3: " + transform.position);

        while (flt_CurrentTime < 1) {


            flt_CurrentTime += Time.deltaTime / motionTime;
            transform.rotation = Quaternion.Lerp(StartRotation, _targetRotation, flt_CurrentTime);

            yield return null;
        }
        flt_CurrentTime = 0;
       
         StartRotation = transform.rotation;
        if (isTop) {
            _targetRotation = Quaternion.Euler(-180, 0, 360);
        }
        else {
            _targetRotation = Quaternion.Euler(0, 0, 360);
        }

        while (flt_CurrentTime < 1) {


            flt_CurrentTime += Time.deltaTime / motionTime;
            
            transform.rotation = Quaternion.Lerp(StartRotation, _targetRotation, flt_CurrentTime);

            yield return null;
        }
        if (isTop) {
            transform.rotation = Quaternion.Euler(-180, 0, 0);
        }
        else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    private IEnumerator MotionAnimation(Quaternion _targetRotation) {
        float flt_CurrentTime = 0;
        Quaternion StartRotation = transform.rotation;

        float motionTime = 0.5f;

       

        while (flt_CurrentTime < 1) {


            flt_CurrentTime += Time.deltaTime / motionTime;
            //  transform.position = Vector3.Lerp(startPostion, tartgetPostion, flt_CurrentTime);
            transform.rotation = Quaternion.Lerp(StartRotation, _targetRotation, flt_CurrentTime);

            yield return null;
        }

        // transform.position = tartgetPostion;
        transform.rotation = _targetRotation;
    }
}
