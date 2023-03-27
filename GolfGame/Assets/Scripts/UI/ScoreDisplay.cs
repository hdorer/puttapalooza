using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    [SerializeField] private GameObject[] scoreSlots;
    private Text[] scoreTexts;

    private Text[] activeScoreSlots;

    private void Awake() {
        scoreTexts = new Text[scoreSlots.Length];
        for(int i = 0; i < scoreTexts.Length; i++) {
            scoreTexts[i] = scoreSlots[i].GetComponentInChildren<Text>();
        }

        activeScoreSlots = new Text[Mathf.Min(GameManager.NumPlayers, scoreSlots.Length)];
        for(int i = 0; i < activeScoreSlots.Length; i++) {
            activeScoreSlots[i] = scoreTexts[GameManager.NumPlayers - 1 - i];
        }
    }

    private void Start() {
        for(int i = GameManager.NumPlayers; i < scoreSlots.Length; i++) {
            scoreSlots[i].SetActive(false);
        }
    }

    public void updateScoreText(int slot, int score) {
        activeScoreSlots[slot].text = score.ToString();
    }
}
