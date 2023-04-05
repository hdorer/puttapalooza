using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoubleHit", menuName = "ScriptableObjects/Powerups/DoubleHit")]
public class DoubleHit : Powerup {
    public override void use(PlayerPowerups ball) {
        ball.GetComponent<PlayerTurn>().activateDoubleHit();
    }
}
