using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : ScriptableObject {
    [SerializeField] private string powerupName;
    [SerializeField] private string description;
    public string Name { get { return powerupName; } }
    
    public abstract void use(PlayerPowerups ball);
}
