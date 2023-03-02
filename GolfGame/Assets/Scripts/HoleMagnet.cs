using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HoleMagnet", menuName = "ScriptableObjects/Powerups/HoleMagnet")]
public class HoleMagnet : Powerup {
    public override void use(PlayerPowerups ball) {
        ball.GetComponent<PlayerMovement>().activateMagnet();
    }
}
