using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    [SerializeField] private float flt_DelayDestroy;
    void Start() {
        StartCoroutine(Dealy_Detroyed());
    }

    private IEnumerator Dealy_Detroyed() {
        yield return new WaitForSeconds(flt_DelayDestroy);
        Destroy(gameObject);
    }
}

   
