using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour {
    private int totalScore = 0;
    private int currentScore = 0;

    private PlayerTurn turn;

    public int TotalScore { get => totalScore; }
    public int CurrentScore { get => currentScore; }

    private void Awake() {
        turn = GetComponent<PlayerTurn>();
    }

    public void increaseScore() {
        totalScore++;
        currentScore++;
        LevelManager.updateScoreText(this);
    }

    public void resetScore() {
        totalScore--;
        currentScore--;
        LevelManager.updateScoreText(this);
    }

    public void saveScore() {
        GameManager.saveScore(turn.Id, LevelManager.LevelId, currentScore);
    }
}
