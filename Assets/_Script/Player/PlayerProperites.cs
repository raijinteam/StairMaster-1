using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperites : MonoBehaviour
{
    [SerializeField] private bool isPlayerUnlocked;
    [SerializeField] private int playerUnlockedPrice;
    

    public bool GetStatusPlayerUnlocked() {
        return isPlayerUnlocked;
    }

    public void SetPlayerUnLockedStatus(bool status) {
        isPlayerUnlocked = status;
    }
    public int GetPriceOfPlayer() {
        return playerUnlockedPrice;
    }

}
