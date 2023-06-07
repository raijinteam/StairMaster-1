using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableObstackle : MonoBehaviour
{
    [SerializeField] private Sprite[] all_Sprite;
    [SerializeField] private SpriteRenderer spriteRenderer;


    private void Start() {
        spriteRenderer.sprite = all_Sprite[Random.Range(0, all_Sprite.Length)];
    }
}
