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

    // TODO: figure out a way to make this event-based
    [SerializeField] private PlayerScore[] pScores;

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

        for(int i = 0; i < scoreLabels.GetLength(0); i++) {
            int j;
            for(j = 0; i < pScores[i].numHoleScores; i++) {
                scoreLabels[i, j].text = pScores[i].getHoleScore(j).ToString();
            }
            scoreLabels[i, j].text = pScores[i].CurrentScore.ToString();

            totalScoreLabels[i].text = pScores[i].TotalScore.ToString();
        }
    }

    private void hideScoreDisplay() {
        scoreDisplayPanel.SetActive(false);
    }
}
