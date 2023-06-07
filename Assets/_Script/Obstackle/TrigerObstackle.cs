using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerObstackle : MonoBehaviour
{
    private string tag_Enemy = "Enemy";
    private string tag_Coin = "Coin";
  

   
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag(tag_Enemy)) {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag(tag_Coin)) {
            Destroy(collision.gameObject);
        }
       
    }
}
