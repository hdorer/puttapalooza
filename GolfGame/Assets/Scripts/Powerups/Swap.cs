using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Swap", menuName = "ScriptableObjects/Powerups/Swap")]
public class Swap : Powerup {
    public override void use(PlayerPowerups ball) {
        if(GameManager.NumPlayers < 2) {
            return;
        }

        GameObject target = LevelManager.getRandomPlayer(ball.GetComponent<PlayerTurn>().Id);
        
        Vector3 position = ball.transform.position;
        Vector3 targetPosition = target.transform.position;

        ball.transform.position = targetPosition;
        target.transform.position = position;        
    }
}
