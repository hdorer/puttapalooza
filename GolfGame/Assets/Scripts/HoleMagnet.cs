using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HoleMagnet", menuName = "ScriptableObjects/HoleMagnet")]
public class HoleMagnet : Powerup {
    public override void use(PlayerPowerups ball) {
        ball.GetComponent<NewBallMovement>().IsMagnetized = true;
    }
}
