using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour {
    private bool initialized = false;
    private bool isTurn = false;

    private int id;

    public bool IsTurn { get => isTurn; }
    public int Id { get => id; }

    public void initialize(PlayerData player) {
        if(initialized) {
            return;
        }

        id = player.id;
        Debug.Log(gameObject.name + " ID: " + id);

        initialized = true;
    }

    public void startTurn() {
        isTurn = true;

        LevelManager.updateButtonState(GetComponent<PlayerMovement>(), GetComponent<PlayerPowerups>());
        LevelManager.updateScoreText(GetComponent<PlayerScore>());
    }

    public void endTurn() {
        isTurn = false;

        LevelManager.goToNextTurn();
    }
}
