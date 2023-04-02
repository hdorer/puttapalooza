using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class FullScoreDisplay : MonoBehaviour {
    private TextMeshProUGUI[,] scoreLabels;
    private TextMeshProUGUI[] totalScoreLabels;

    [SerializeField] GameObject scoreDisplayPanel;

    [SerializeField] private InputAction showScoreDisplayInput;

    private void OnEnable() {
        showScoreDisplayInput.Enable();

        showScoreDisplayInput.performed += context => show();
        showScoreDisplayInput.canceled += context => hide();
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

    public void disableInput() {
        showScoreDisplayInput.Disable();
    }

    public void show() {
        scoreDisplayPanel.SetActive(true);

        for(int i = 0; i < GameManager.NumPlayers; i++) {
            int[] scores = GameManager.getHoleScores(i);
            for(int j = 0; j < GameManager.NumHoles; j++) {
                scoreLabels[i, j].text = scores[j].ToString();
            }
            scoreLabels[i, LevelManager.LevelId].text = LevelManager.getPlayerCurrentScore(i).ToString();

            totalScoreLabels[i].text = LevelManager.getPlayerTotalScore(i).ToString();
        }
    }

    private void hide() {
        scoreDisplayPanel.SetActive(false);
    }
}
