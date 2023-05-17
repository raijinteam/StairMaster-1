using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [Header("Componant")]
    [SerializeField] private Playermovement playermovement;


    [Header("VFX")]
    [SerializeField] private GameObject dievfx;
    // Tag
    private string tag_Enemy = "Enemy";
    private string tag_Boundry = "Boundry";
    private string tag_Coin = "Coin";
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (!GameManager.instance.isplayerLive) {
            return;
        }
        if (collision.gameObject.CompareTag(tag_Enemy)) {
            AudioManager.instance.PlayDieSFX();
            Debug.Log("GameOver");
            GameManager.instance.isplayerLive = false;
            playermovement.myBody.gameObject.SetActive(false);
            Instantiate(dievfx, transform.position, transform.rotation);
            UiManager.instance.SetUiGameOverScreen();
            

        }
        if (collision.gameObject.CompareTag(tag_Boundry)) {
            AudioManager.instance.PlayDieSFX();
            Debug.Log("GameOver");
            GameManager.instance.isplayerLive = false;
            playermovement.myBody.gameObject.SetActive(false);
            Instantiate(dievfx, transform.position, transform.rotation);
            UiManager.instance.SetUiGameOverScreen();

        }
        if (collision.gameObject.CompareTag(tag_Coin)) {

            AudioManager.instance.PlayCoinCollectSFX();
            GameManager.instance.IncresedGameCoin();
            collision.GetComponent<Coin>().PlayCoinvfx();
            Destroy(collision.gameObject);
        }
    }

   
}
