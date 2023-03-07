using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mulligan", menuName = "ScriptableObjects/Powerups/Mulligan")]
public class Mulligan : Powerup {
    public override void use(PlayerPowerups ball) {
        ball.GetComponent<PlayerMovement>().doMulligan();
        ball.GetComponent<PlayerScore>().resetScore();
    }
}
