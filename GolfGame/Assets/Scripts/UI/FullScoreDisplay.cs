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
    private bool inputEnabled = true;

    private void OnEnable() {
        showScoreDisplayInput.Enable();

        showScoreDisplayInput.performed += context => show(false);
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

    public void show(bool disableInput) {
        if(!inputEnabled) {
            return;
        }

        scoreDisplayPanel.SetActive(true);

        for(int i = 0; i < GameManager.NumPlayers; i++) {
            Debug.Log("for loop 1");
            int[] scores = GameManager.getHoleScores(i);
            for(int j = 0; j < GameManager.NumHoles; j++) {
                Debug.Log("for loop 2");
                scoreLabels[i, j].text = scores[j].ToString();
            }
            scoreLabels[i, LevelManager.LevelId].text = LevelManager.getPlayerCurrentScore(i).ToString();

            totalScoreLabels[i].text = GameManager.Players[i].totalScore.ToString();
        }

        inputEnabled = !disableInput;
    }

    private void hide() {
        if(!inputEnabled) {
            return;
        }

        scoreDisplayPanel.SetActive(false);
    }
}
