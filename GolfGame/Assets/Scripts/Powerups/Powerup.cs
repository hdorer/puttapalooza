using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : ScriptableObject {
    [SerializeField] private string powerupName;
    [SerializeField] private string description;
    [SerializeField] private Sprite powerupSprite;
    public string Name { get { return powerupName; } }
    public Sprite Sprite { get { return powerupSprite; } }
    
    public abstract void use(PlayerPowerups ball);
}
