using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class FullScoreDisplay : MonoBehaviour {
    private TextMeshProUGUI[,] scoreLabels;
    private TextMeshProUGUI[] totalScoreLabels;

    [SerializeField] GameObject scoreDisplayPanel;

    [SerializeField] private InputAction showScoreDisplayInput;

    private void OnEnable() {
        showScoreDisplayInput.Enable();

        showScoreDisplayInput.performed += context => showScoreDisplay();
        showScoreDisplayInput.canceled += context => hideScoreDisplay();
    }

    private void OnDisable() {
        showScoreDisplayInput.Disable();
    }

    public void initializeArrays(int players, int holes) {
        scoreLabels = new TextMeshProUGUI[players, holes];
        totalScoreLabels = new TextMeshProUGUI[players];
    }

    public void addScoreLabel(int player, int hole, TextMeshProUGUI scoreLabel) {
        scoreLabels[player, hole] = scoreLabel;
    }

    public void addScoreLabel(int player, TextMeshProUGUI scoreLabel) {
        totalScoreLabels[player] = scoreLabel;
    }

    private void showScoreDisplay() {
        scoreDisplayPanel.SetActive(true);

        for(int i = 0; i < GameManager.Players; i++) {
            int[] scores = GameManager.getHoleScores(i);
            for(int j = 0; j < GameManager.Holes; j++) {
                scoreLabels[i, j].text = scores[j].ToString();
            }
            scoreLabels[i, LevelManager.LevelId].text = LevelManager.getPlayerScore(i).CurrentScore.ToString();

            totalScoreLabels[i].text = LevelManager.getPlayerScore(i).TotalScore.ToString();
        }
    }

    private void hideScoreDisplay() {
        scoreDisplayPanel.SetActive(false);
    }
}
