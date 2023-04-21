using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerPowerups : MonoBehaviour {
    private bool initialized = false;

    private Powerup powerup;

    private PlayerMovement movement;
    private PlayerTurn turn;

    [SerializeField] private InputAction usePowerupInput;

    public Powerup Powerup { get => powerup; }
    public bool hasPowerup { get => powerup != null; }
    public int Id { get => turn.Id; }

    private void OnEnable() {
        usePowerupInput.Enable();

        usePowerupInput.performed += usePowerup;
    }

    private void Awake() {
        movement = GetComponent<PlayerMovement>();
        turn = GetComponent<PlayerTurn>();
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

    public void savePowerup() {
        GameManager.savePowerup(turn.Id, powerup);
    }
    
    private void usePowerup(InputAction.CallbackContext context) {
        if(powerup == null) {
            return;
        }

        GetComponent<PlayerAudio>().playPowerupUse();
        powerup.use(this);
        powerup = null;
        LevelManager.updateButtonState(movement, this);
    }
}
