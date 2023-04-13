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
    private int[] playerIds;

    public delegate void PowerupEffect(int player);
    private PowerupEffect effect;

    private void Awake() {
        buttonImages = new Image[buttons.Length];
        texts = new TextMeshProUGUI[buttons.Length];

        for(int i = 0; i < buttons.Length; i++) {
            buttonImages[i] = buttons[i].GetComponentInChildren<Image>();
            texts[i] = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public void show(int playerToExclude, PowerupEffect effect) {
        panel.SetActive(true);
        this.effect = effect;

        playerIds = new int[buttons.Length];
        int index = 0;
        for(int i = 0; i < GameManager.NumPlayers; i++) {
            if(i == playerToExclude) {
                continue;
            }

            playerIds[index] = i;
            index++;
        }

        for(int i = 0; i < buttons.Length; i++) {
            buttons[i].gameObject.SetActive(true);
            texts[i].text = "Player " + (playerIds[i] + 1);
            buttonImages[i].color = GameManager.Players[playerIds[i]].color;

            index++;
        }
    }

    public void hide() {
        for(int i = 0; i < buttons.Length; i++) {
            buttons[i].gameObject.SetActive(false);
        }

        panel.SetActive(false);
    }

    public void doEffect(int index) {
        effect(playerIds[index]);
    }
}
