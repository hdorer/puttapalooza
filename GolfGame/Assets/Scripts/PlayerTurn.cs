using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour {
    private bool initialized = false;
    private bool isTurn = false;
    private bool holeCompleted = false;

    private bool doubleHit = false;

    private int id;

    private PlayerMovement movement;
    private PlayerPowerups powerups;
    private PlayerScore score;

    public bool IsTurn { get => isTurn; }
    public bool HoleCompleted { get => holeCompleted; }
    public int Id { get => id; }

    private void OnEnable() {
        Debug.Log(gameObject.name + " OnEnable()");
    }

    private void Awake() {
        movement = GetComponent<PlayerMovement>();
        powerups = GetComponent<PlayerPowerups>();
        score = GetComponent<PlayerScore>();
    }

    public void initialize(int id, Color color) {
        if(initialized) {
            return;
        }

        this.id = id;
        GetComponent<Renderer>().material.color = color;

        initialized = true;
    }

    public void startTurn() {
        isTurn = true;

        LevelManager.updateButtonState(movement, powerups);
        LevelManager.updateScoreText(score);
    }

    public void endTurn(bool increaseScore) {
        if(doubleHit && !holeCompleted) {
            doubleHit = false;
            startTurn();
            movement.doubleHitPenalty();
            return;
        }

        if(increaseScore) {
            GetComponent<PlayerScore>().increaseScore();
        }

        isTurn = false;
        LevelManager.goToNextTurn();
    }

    public void completeHole() {
        score.increaseScore();
        score.saveScore();
        powerups.savePowerup();

        holeCompleted = true;
    }

    public void activateDoubleHit() {
        doubleHit = true;
    }
}
