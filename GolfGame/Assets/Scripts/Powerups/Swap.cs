using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : Powerup {
    public override void use(PlayerPowerups ball) {
        GameObject target = LevelManager.getRandomPlayer(ball.GetComponent<PlayerTurn>().Id);
        
        Vector3 position = ball.transform.position;
        Vector3 targetPosition = target.transform.position;

        ball.transform.position = targetPosition;
        target.transform.position = position;        
    }
}
