using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerDisplay : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image panel;
    [SerializeField] private int mainMenuIndex;

    public void show(PlayerData winner) {
        panel.gameObject.SetActive(true);
        panel.color = winner.color;
        text.text = "Player " + (winner.id + 1) + " wins!";
    }

    public void goToMainMenu() {
        SceneManager.LoadScene(mainMenuIndex);
    }
}
