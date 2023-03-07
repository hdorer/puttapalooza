using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FullScoreDisplay : MonoBehaviour {
    private TextMeshProUGUI[,] scoreLabels;
    private TextMeshProUGUI[] totalScoreLabels;

    [SerializeField] GameObject scoreDisplayPanel;
    [SerializeField] private InputAction showScoreDisplayInput;

    private void OnEnable() {
        showScoreDisplayInput.Enable();

        showScoreDisplayInput.performed += showScoreDisplay;
        showScoreDisplayInput.canceled += hideScoreDisplay;
    }

    private void OnDisable() {
        showScoreDisplayInput.Disable();

        showScoreDisplayInput.performed -= showScoreDisplay;
        showScoreDisplayInput.canceled -= hideScoreDisplay;
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

    private void showScoreDisplay(InputAction.CallbackContext context) {
        showScoreDisplay();
    }

    private void showScoreDisplay() {
        scoreDisplayPanel.SetActive(true);
    }

    private void hideScoreDisplay(InputAction.CallbackContext context) {
        hideScoreDisplay();
    }

    private void hideScoreDisplay() {
        scoreDisplayPanel.SetActive(false);
    }
}
