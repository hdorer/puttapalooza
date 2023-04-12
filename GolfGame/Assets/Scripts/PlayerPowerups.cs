using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerPowerups : MonoBehaviour {
    private bool initialized = false;

    private Powerup powerup;

    private PlayerMovement movement;

    [SerializeField] private InputAction usePowerupInput;

    public Powerup Powerup { get => powerup; }
    public bool hasPowerup { get => powerup != null; }

    private void OnEnable() {
        usePowerupInput.Enable();

        usePowerupInput.performed += usePowerup;
    }

    private void Awake() {
        movement = GetComponent<PlayerMovement>();
    }

    private void OnDisable() {
        usePowerupInput.Disable();

        usePowerupInput.performed -= usePowerup;
    }

    public void initialize(Powerup powerup) {
        if(initialized) {
            return;
        }

        this.powerup = powerup;
        LevelManager.updateButtonState(movement, this);

        initialized = true;
    }

    public void setPowerup(Powerup powerup) {
        this.powerup = powerup;
        LevelManager.updateButtonState(movement, this);
    }

    public void usePowerup() {
        if(powerup == null) {
            return;
        }

        powerup.use(this);
        powerup = null;
        LevelManager.updateButtonState(movement, this);
    }
    
    private void usePowerup(InputAction.CallbackContext context) {
        if(powerup == null) {
            return;
        }

        powerup.use(this);
        powerup = null;
        LevelManager.updateButtonState(movement, this);
    }
}
