using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerPowerups : MonoBehaviour {
    private Powerup powerup;
    public Powerup Powerup { get => powerup; }
    public bool hasPowerup { get => powerup != null; }

    [SerializeField] private InputAction usePowerupInput;

    private void OnEnable() {
        usePowerupInput.Enable();

        usePowerupInput.performed += usePowerup;
    }

    private void OnDisable() {
        usePowerupInput.Disable();

        usePowerupInput.performed -= usePowerup;
    }

    public void setPowerup(Powerup powerup) {
        this.powerup = powerup;
        LevelManager.updateButtonState(GetComponent<PlayerMovement>(), this);
    }

    public void usePowerup() {
        if(powerup == null) {
            return;
        }

        powerup.use(this);
        powerup = null;
        LevelManager.updateButtonState(GetComponent<PlayerMovement>(), this);
    }
    
    private void usePowerup(InputAction.CallbackContext context) {
        if(powerup == null) {
            return;
        }

        powerup.use(this);
        powerup = null;
        LevelManager.updateButtonState(GetComponent<PlayerMovement>(), this);
    }
}
