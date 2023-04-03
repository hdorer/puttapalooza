using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData {
    public int id { get; private set; }
    public int difficulty { get; private set; }
    public Powerup startingPowerup { get; private set; }
    public Color color { get; private set; }

    public int[] holeScores { get; private set; }
    public int totalScore { get; set; }

    public PlayerData(int id, int difficulty, Powerup startingPowerup, Color color) {
        this.id = id;
        this.difficulty = difficulty;
        this.startingPowerup = startingPowerup;
        this.color = color;

        holeScores = new int[GameManager.NumHoles];
        totalScore = 0;
    }
}
