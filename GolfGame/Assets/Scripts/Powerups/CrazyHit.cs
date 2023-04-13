using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CrazyHit", menuName = "ScriptableObjects/Powerups/CrazyHit")]
public class CrazyHit : Powerup {
    public override void use(PlayerPowerups ball) {
        ball.GetComponent<PlayerMovement>().activateCrazyHit();
    }
}
