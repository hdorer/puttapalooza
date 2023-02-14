using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPowerups : MonoBehaviour {
    private Powerup powerup;
    public Powerup Powerup { get => powerup; set => setPowerup(value); }
    public bool hasPowerup { get => powerup != null; }

    public UnityEvent onPowerupUpdate;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            usePowerup();
        }
    }

    private void setPowerup(Powerup value) {
        powerup = value;
        onPowerupUpdate?.Invoke();
    }
    
    public void usePowerup() {
        powerup.use(this);
        powerup = null;
        onPowerupUpdate?.Invoke();
    }
}
