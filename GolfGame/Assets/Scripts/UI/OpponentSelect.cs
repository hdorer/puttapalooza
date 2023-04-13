using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpponentSelect : MonoBehaviour {
    [SerializeField] private GameObject panel;
    [SerializeField] private Button[] buttons;
    private Image[] buttonImages;
    private TextMeshProUGUI[] texts;

    private void Awake() {
        buttonImages = new Image[buttons.Length];
        texts = new TextMeshProUGUI[buttons.Length];

        for(int i = 0; i < buttons.Length; i++) {
            buttonImages[i] = buttons[i].GetComponentInChildren<Image>();
            texts[i] = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public void show(int playerToExclude) {
        panel.SetActive(true);

        int index = 0;
        for(int i = 0; i < GameManager.NumPlayers; i++) {
            if(i == playerToExclude) {
                continue;
            }

            buttons[index].gameObject.SetActive(true);
            texts[index].text = "Player " + (i + 1);
            buttonImages[index].color = GameManager.Players[i].color;

            index++;
        }
    }
}
