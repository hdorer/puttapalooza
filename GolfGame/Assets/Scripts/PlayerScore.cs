using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour {
    private int totalScore = 0;
    public int TotalScore { get => totalScore; }
    private int currentScore = 0;
    public int CurrentScore { get => currentScore; }

    [SerializeField] private int playerId = 0;

    private List<int> holeScores = new List<int>();
    public int numHoleScores { get => holeScores.Count; }

    [System.Serializable] public class ScoreUpdateEvent : UnityEvent<int> { }
    public ScoreUpdateEvent onScoreUpdate;

    public void increaseScore() {
        totalScore++;
        currentScore++;
        onScoreUpdate?.Invoke(totalScore);
    }

    public void resetScore() {
        totalScore--;
        currentScore--;
        onScoreUpdate?.Invoke(totalScore);
    }

    public void saveScore() {
        GameManager.saveScore(playerId, LevelManager.LevelId, currentScore);
    }
}
