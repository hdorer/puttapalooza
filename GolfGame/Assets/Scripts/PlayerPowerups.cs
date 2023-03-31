using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerPowerups : MonoBehaviour {
    private bool initialized = false;

    private Powerup powerup;

    private PlayerMovement pMovement;

    [SerializeField] private InputAction usePowerupInput;

    public Powerup Powerup { get => powerup; }
    public bool hasPowerup { get => powerup != null; }

    private void OnEnable() {
        usePowerupInput.Enable();

        usePowerupInput.performed += usePowerup;
    }

    private void Awake() {
        pMovement = GetComponent<PlayerMovement>();
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
        LevelManager.updateButtonState(pMovement, this);

        initialized = true;
    }

    public void setPowerup(Powerup powerup) {
        this.powerup = powerup;
        LevelManager.updateButtonState(pMovement, this);
    }

    public void usePowerup() {
        if(powerup == null) {
            return;
        }

        powerup.use(this);
        powerup = null;
        LevelManager.updateButtonState(pMovement, this);
    }
    
    private void usePowerup(InputAction.CallbackContext context) {
        if(powerup == null) {
            return;
        }

        powerup.use(this);
        powerup = null;
        LevelManager.updateButtonState(pMovement, this);
    }
}
