using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour {
    private int totalScore = 0;
    private int currentScore = 0;

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
}
