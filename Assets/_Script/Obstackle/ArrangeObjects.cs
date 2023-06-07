using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangeObjects : MonoBehaviour
{
    [SerializeField] private Transform[] all_Stairs;
    [SerializeField] private float stairOffsetY;
    [SerializeField] private float stairOffsetX;
    [SerializeField] private float flt_PathOffset;
    [SerializeField] private Transform[] all_Path;
    


    [ContextMenu("Arrange Stairs")]
    void ArrangeStairs() {

        for (int i = 1; i < all_Stairs.Length; i++) {

            all_Stairs[i].transform.position = new Vector3(all_Stairs[i - 1].position.x + stairOffsetX,
                all_Stairs[i - 1].position.y + stairOffsetY,
                all_Stairs[i].transform.position.z);

        }
        for (int i = 1; i < all_Path.Length; i++) {

            all_Stairs[i].transform.position = new Vector3(all_Stairs[i - 1].position.x + flt_PathOffset,
                all_Stairs[i - 1].position.y + stairOffsetY,
                all_Stairs[i].transform.position.z);

        }
    }
}
