using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    [SerializeField] Text scoreText;

    public void updateScoreText(int score) {
        scoreText.text = score.ToString();
    }
}
