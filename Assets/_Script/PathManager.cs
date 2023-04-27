using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathManager : MonoBehaviour
{
    public static PathManager instance;
    public bool isTimeToBlankTopPath;
    public bool isTimeToBlankDownPath;
 

    [SerializeField] private PathMovement topPath;
    [SerializeField] private PathMovement downPath;

    private void Awake() {
        instance = this;
    }
    private void Start() {
        isTimeToBlankDownPath = true;
        downPath.isTimeToGap = true;
    }
    public void SetOtherPath() {

        
            if (isTimeToBlankDownPath) {
                isTimeToBlankTopPath = true;
                topPath.isTimeToGap = true;
                downPath.isTimeToGap = false;
                isTimeToBlankDownPath = false;
            }
            else {
                isTimeToBlankTopPath = false;
                topPath.isTimeToGap = false;
                downPath.isTimeToGap = true;
                isTimeToBlankDownPath = true;
            }
        
       
    }

   
}
