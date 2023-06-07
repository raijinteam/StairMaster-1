using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    [SerializeField] private float flt_DelayDestroy;
    public float flt_Speed;
    void Start() {
        StartCoroutine(Dealy_Detroyed());
    }
    
    private void Update() {
        if (!GameManager.instance.isplayerLive) {
            return;
        }
        transform.Translate(new Vector3(-1, -1, 0) * 3 * Time.deltaTime);
    }

    private IEnumerator Dealy_Detroyed() {
        yield return new WaitForSeconds(flt_DelayDestroy);
        Destroy(gameObject);
    }
}

   
