using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour {
    private int currentScore = 0;

    private PlayerTurn turn;

    public int CurrentScore { get => currentScore; }

    private void Awake() {
        turn = GetComponent<PlayerTurn>();
    }

    public void increaseScore() {
        currentScore++;
        LevelManager.updateScoreText(this);
    }

    public void resetScore() {
        currentScore--;
        LevelManager.updateScoreText(this);
    }

    public void saveScore() {
        GameManager.saveScore(turn.Id, LevelManager.LevelId, currentScore);
    }
}
