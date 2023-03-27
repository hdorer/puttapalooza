using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    [SerializeField] private GameObject[] scoreSlots;
    Text[] scoreTexts;

    private void Awake() {
        scoreTexts = new Text[scoreSlots.Length];
        for(int i = 0; i < scoreTexts.Length; i++) {
            scoreTexts[i] = scoreSlots[i].GetComponentInChildren<Text>();
        }
    }

    private void Start() {
        for(int i = GameManager.NumPlayers; i < scoreSlots.Length; i++) {
            scoreSlots[i].SetActive(false);
        }
    }

    public void updateScoreText(int slot, int score) {
        scoreTexts[slot].text = score.ToString();
    }
}
