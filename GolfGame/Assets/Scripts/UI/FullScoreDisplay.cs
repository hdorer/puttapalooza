using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScoreDisplay : MonoBehaviour {
    private TextMeshProUGUI[,] scoreLabels;
    private TextMeshProUGUI[] totalScoreLabels;

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
}
