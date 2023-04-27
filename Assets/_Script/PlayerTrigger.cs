using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private Playermovement playermovement;
    private string tag_Enemy = "Enemy";
    private string tag_Boundry = "Boundry";
    [SerializeField] private GameObject dievfx;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag(tag_Enemy)) {
            Debug.Log("GameOver");
            GameManager.instance.isplayerLive = false;
            Instantiate(dievfx, transform.position, transform.rotation);
            Destroy(playermovement.myBody.gameObject);
            Destroy(gameObject);
            UiManager.instance.SetUiGameOverScreen();

        }
        if (collision.gameObject.CompareTag(tag_Boundry)) {
            Debug.Log("GameOver");
            GameManager.instance.isplayerLive = false;
            Instantiate(dievfx, transform.position, transform.rotation);
            Destroy(playermovement.myBody.gameObject);
            Destroy(gameObject);
            UiManager.instance.SetUiGameOverScreen();

        }
    }

   
}
