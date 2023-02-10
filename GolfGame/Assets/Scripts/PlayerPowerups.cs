using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPowerups : MonoBehaviour {
    private Powerup powerup;
    public Powerup Powerup { get => powerup; set => setPowerup(value); }
    public bool hasPowerup { get => powerup != null; }

    public UnityEvent onPowerupUpdate;

    private void setPowerup(Powerup value) {
        powerup = value;
        onPowerupUpdate?.Invoke();
    }
    
    public void usePowerup() {
        Debug.Log("this code is being reached");
        powerup.use(this);
        powerup = null;
        onPowerupUpdate?.Invoke();
    }
}
