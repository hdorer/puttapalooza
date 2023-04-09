using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour {
    private bool initialized = false;
    private bool isTurn = false;
    private bool holeCompleted = false;

    private bool doubleHit = false;

    private int id;

    public bool IsTurn { get => isTurn; }
    public bool HoleCompleted { get => holeCompleted; }
    public int Id { get => id; }

    public void initialize(int id, Color color) {
        if(initialized) {
            return;
        }

        this.id = id;
        Debug.Log(gameObject.name + " ID: " + this.id);
        GetComponent<Renderer>().material.color = color;

        initialized = true;
    }

    public void startTurn() {
        isTurn = true;

        LevelManager.updateButtonState(GetComponent<PlayerMovement>(), GetComponent<PlayerPowerups>());
        LevelManager.updateScoreText(GetComponent<PlayerScore>());
    }

    public void endTurn(bool increaseScore) {
        if(doubleHit && !holeCompleted) {
            doubleHit = false;
            startTurn();
            GetComponent<PlayerMovement>().doubleHitPenalty();
            return;
        }

        if(increaseScore) {
            GetComponent<PlayerScore>().increaseScore();
        }

        isTurn = false;
        LevelManager.goToNextTurn();
    }

    public void completeHole() {
        GetComponent<PlayerScore>().increaseScore();
        GetComponent<PlayerScore>().saveScore();

        holeCompleted = true;
    }

    public void activateDoubleHit() {
        doubleHit = true;
    }
}
