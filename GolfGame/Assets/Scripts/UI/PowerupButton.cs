using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupButton : MonoBehaviour {
    private Button button;
    [SerializeField] private Text text;
    [SerializeField] private Image power;
    [SerializeField] private Sprite powerup, def;

    private void Awake() {
        button = GetComponent<Button>();
    }

    public void updateButtonState(PlayerMovement pMovement, PlayerPowerups pPowerups) {
        button.interactable = pPowerups.hasPowerup && pMovement.IsAim; // this could still be better
        text.text = pPowerups.hasPowerup ? pPowerups.Powerup.Name : "[No powerup]";
        power.sprite = pPowerups.hasPowerup ? pPowerups.Powerup.Sprite : def;
    }
}
