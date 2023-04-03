using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour {
    private int totalScore = 0;
    public int TotalScore { get => totalScore; }
    private int currentScore = 0;
    public int CurrentScore { get => currentScore; }

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
        GameManager.saveScore(GetComponent<PlayerTurn>().Id, LevelManager.LevelId, currentScore, totalScore);
    }
}
