using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupButton : MonoBehaviour {
    private Button button;
    [SerializeField] private Text text;

    [SerializeField] private NewBallMovement pMovement;
    [SerializeField] private PlayerPowerups pPowerups;

    private void Awake() {
        button = GetComponent<Button>();
    }

    public void updateButtonState() {
        button.interactable = pPowerups.hasPowerup && pMovement.IsIdle && !pMovement.IsAiming;
        text.text = pPowerups.hasPowerup ? pPowerups.Powerup.Name : "[No powerup]";
    }
}
